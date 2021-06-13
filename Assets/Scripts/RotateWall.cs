using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWall : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * 120f);
    }
}
