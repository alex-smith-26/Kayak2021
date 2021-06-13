using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMoveWall : MonoBehaviour
{

    public bool goingUp = false;
    [SerializeField] public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -2.8)
        {
            goingUp = true;
            transform.position = transform.position + new Vector3(0, moveSpeed, 0);
        }
        else if (goingUp && transform.position.y < 2.8)
        {
            transform.position = transform.position + new Vector3(0, moveSpeed, 0);
        }
        else if (!goingUp && transform.position.y < 2.8)
        {
            transform.position = transform.position - new Vector3(0, moveSpeed, 0);
        }
        else if (transform.position.y >= 2.8)
        {
            goingUp = false;
            transform.position = transform.position - new Vector3(0, moveSpeed, 0);
        }
    }
}
