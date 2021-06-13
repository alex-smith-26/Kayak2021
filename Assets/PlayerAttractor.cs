using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttractor : MonoBehaviour
{


    private List<GameObject> players;

    [SerializeField] private float PullPower = 12f;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
    }


    private void FixedUpdate()
    {
        foreach(GameObject g in players)
        {
            Vector2 diff = transform.position - g.transform.position;
            diff /= diff.sqrMagnitude;

            var max = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y));
            if (max < 0.4f)
            {
                diff *= 0.4f / max;
            }

            g.GetComponent<Rigidbody2D>().AddForce(diff * PullPower);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            players.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            players.Remove(collision.gameObject);
        }
    }
}
