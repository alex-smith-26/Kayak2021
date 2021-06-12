using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayakMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [SerializeField] public float thrust = .05f;

    [SerializeField] GameObject topLeftThruster;
    [SerializeField] GameObject topRightThruster;
    [SerializeField] GameObject bottomLeftThruster;
    [SerializeField] GameObject bottomRightThruster;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            print("W key was pressed");

            rb2D.AddForceAtPosition(thrust * -topLeftThruster.transform.up, topLeftThruster.transform.position);
            topLeftThruster.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else
        {
            topLeftThruster.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb2D.AddForceAtPosition(thrust * -bottomLeftThruster.transform.up, bottomLeftThruster.transform.position);

            bottomLeftThruster.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else
        {
            bottomLeftThruster.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.AddForceAtPosition(thrust * -topRightThruster.transform.up, topRightThruster.transform.position);


            topRightThruster.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else
        {
            topRightThruster.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2D.AddForceAtPosition(thrust * -bottomRightThruster.transform.up, bottomRightThruster.transform.position);


            bottomRightThruster.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else
        {
            bottomRightThruster.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
    }

}
