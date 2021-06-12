using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TugofwarMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;
    // private Vector3 leftEuler = new Vector3();
    // private Vector3 rightEuler = new Vector3();

    [SerializeField] public float thrust = 0.05f;

    [SerializeField] GameObject leftThruster;
    [SerializeField] GameObject rightThruster;

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
            rb2D.AddForceAtPosition(thrust * -leftThruster.transform.up, leftThruster.transform.position);
            leftThruster.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else
        {
            leftThruster.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }

        if (Input.GetKey(KeyCode.A)) {
            leftThruster.transform.Rotate(new Vector3(0, 0, 0.5f));
            // leftEuler.z += 0.5f;
        }

        if (Input.GetKey(KeyCode.D)) {
            leftThruster.transform.Rotate(new Vector3(0, 0, -0.5f));
            // leftEuler.z -= 0.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.AddForceAtPosition(thrust * -rightThruster.transform.up, rightThruster.transform.position);
            rightThruster.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else
        {
            rightThruster.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rightThruster.transform.Rotate(new Vector3(0, 0, 0.5f));
            // rightEuler.z += 0.5f;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            rightThruster.transform.Rotate(new Vector3(0, 0, -0.5f));
            // rightEuler.z -= 0.5f;
        }
    }

    // void LateUpdate()
    // {
    //    leftThruster.transform.eulerAngles = leftEuler;
    //    rightThruster.transform.eulerAngles = rightEuler;
    // }

}
