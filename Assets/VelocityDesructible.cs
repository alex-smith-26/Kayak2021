using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDesructible : MonoBehaviour
{
    [SerializeField] private float threshold;

    [HideInInspector] public TargetTracker tracker;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Vector2 vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            if(vel.magnitude > threshold)
            {
                die();
            }
        }
        if( collision.gameObject.CompareTag("Bullet"))
        {
            die();
        }
    }

    public void die()
    {
        if(tracker)
        {
            tracker.NoteDeath();
        }
        Destroy(gameObject);
    }
}
