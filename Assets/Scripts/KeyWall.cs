using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWall : MonoBehaviour
{

    [SerializeField] GameObject WallToOpen;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ship")
        {
            Destroy(WallToOpen);
            Destroy(gameObject);
        }
    }
}
