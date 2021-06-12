using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDesructible : MonoBehaviour
{
    [SerializeField] private float threshold;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Vector2 vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            if(vel.magnitude > threshold)
            {
                Destroy(gameObject);
            }
        }
        if( collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
