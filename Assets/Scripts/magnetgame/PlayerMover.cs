using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private GameObject otherPlayer;

    public enum player { p1 , p2 };

    public player p;

    public float PullPower = 5f;

    public float PushPower = 5f;

    private Rigidbody2D rigidb;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
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
        Vector2 diff = otherPlayer.transform.position - transform.position;
        diff /= diff.sqrMagnitude;

        rigidb.AddForce(diff * PullPower);
    }

    public void push()
    {
        Vector2 diff = transform.position - otherPlayer.transform.position;
        diff /= diff.sqrMagnitude;

        rigidb.AddForce(diff * PushPower);
    }
}
