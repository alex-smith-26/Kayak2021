using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private GameObject otherPlayer;

    public enum player { p1 , p2 };

    public player p;

    private float PullPower = 15f;

    private float PushPower = 15f;

    private Rigidbody2D rigidb;

    private float floor = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();

        if(!otherPlayer)
        {
            GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
            foreach (GameObject ship in ships)
            {
                if(ship != gameObject)
                {
                    otherPlayer = ship;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (p == player.p1)
        {
            if (Input.GetKey(KeyCode.E))
            {
                pull2Other();
            }

            if (Input.GetKey(KeyCode.Q))
            {
                push();
            }
        }
        if (p == player.p2)
        {
            if (Input.GetKey(KeyCode.O))
            {
                pull2Other();
            }

            if (Input.GetKey(KeyCode.U))
            {
                push();
            }
        }
        
    }

    public void pull2Other()
    {
        if(otherPlayer)
        {
            Vector2 diff = otherPlayer.transform.position - transform.position;
            diff /= diff.sqrMagnitude;
            var max = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y));
            if (max < floor)
            {
                diff *= floor / max;
            }

            rigidb.AddForce(diff * PullPower);
        }
        
    }

    public void push()
    {
        if(otherPlayer)
        {
            Vector2 diff = transform.position - otherPlayer.transform.position;
            diff /= diff.sqrMagnitude;

            var max = Mathf.Max(Mathf.Abs(diff.x), Mathf.Abs(diff.y));
            if (max < floor / 2f)
            {
                diff *= floor / 2f / max;
            }

            rigidb.AddForce(diff * PushPower);
        }
        
    }
}
