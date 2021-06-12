using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float rotationFollowStrength;
    public float speed;
    private Rigidbody2D rb2d;
    float CurrentRotation;
    Vector3 VectorToPlayer;
    float angleToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        VectorToPlayer = player.transform.position - rb2d.transform.position;
        angleToPlayer = Vector3.SignedAngle(new Vector2(0.0f, 1.0f), VectorToPlayer, Vector3.forward);
        if (Mathf.Abs(rb2d.rotation - angleToPlayer) < 180)
        {
            rb2d.rotation -= (rb2d.rotation - angleToPlayer) * (rotationFollowStrength / 100);
            print("modRotDiff = " + (rb2d.rotation - angleToPlayer));
        }
        else if (rb2d.rotation-angleToPlayer < -180)
        {
            rb2d.rotation -= (360+(rb2d.rotation-angleToPlayer)) * (rotationFollowStrength / 100);
            print("modRotDiff = " + 360 + (rb2d.rotation - angleToPlayer));
        }
        else if (rb2d.rotation - angleToPlayer > 180)
        {
            rb2d.rotation -= (rb2d.rotation - (angleToPlayer+360)) * (rotationFollowStrength / 100);
            print("modRotDiff = " + (rb2d.rotation - (angleToPlayer + 360)));
        }
        rb2d.transform.position += (VectorToPlayer.normalized) * speed/100;
    }
}
