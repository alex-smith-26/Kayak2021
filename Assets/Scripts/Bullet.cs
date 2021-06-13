using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 10;

    void OnCollisionEnter2D(Collision2D col)
    {
        print("collided with something with tag " + col.gameObject.tag);
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
