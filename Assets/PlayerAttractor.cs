using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttractor : MonoBehaviour
{


    private List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
    }


    private void FixedUpdate()
    {
        foreach(GameObject g in players)
        {
            g.GetComponent<PlayerMover>().pull2Other(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            players.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            players.Remove(collision.gameObject);
        }
    }
}
