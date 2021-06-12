using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDesructible : MonoBehaviour
{
    [SerializeField] private float threshold;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            if(vel.magnitude > threshold)
            {
                Destroy(gameObject);
            }
        }
    }
}
