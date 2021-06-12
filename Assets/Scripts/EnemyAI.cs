using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool hasAggroOnPlayer = false;
    public bool hasSightlineOnPlayer = false;
    public GameObject[] nodes;
    public GameObject player;
    [SerializeField] public enum AIType {Chase, Kamikaze, Cautious};
    public AIType type;
    public float rotationFollowStrength;
    public float speed;
    private Rigidbody2D rb2d;
    Vector3 VectorToPlayer;
    float angleToPlayer;
    private Vector2 desiredPosition;

    void FaceTowardsPlayer()
    {
        if (Mathf.Abs(rb2d.rotation - angleToPlayer) < 180)
        {
            rb2d.rotation -= (rb2d.rotation - angleToPlayer) * (rotationFollowStrength / 100);
            print("modRotDiff = " + (rb2d.rotation - angleToPlayer));
        }
        else if (rb2d.rotation - angleToPlayer < -180)
        {
            rb2d.rotation -= (360 + (rb2d.rotation - angleToPlayer)) * (rotationFollowStrength / 100);
            print("modRotDiff = " + 360 + (rb2d.rotation - angleToPlayer));
        }
        else if (rb2d.rotation - angleToPlayer > 180)
        {
            rb2d.rotation -= (rb2d.rotation - (angleToPlayer + 360)) * (rotationFollowStrength / 100);
            print("modRotDiff = " + (rb2d.rotation - (angleToPlayer + 360)));
        }
    }

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
        RaycastHit2D lineOfSight = Physics2D.Raycast(transform.position, VectorToPlayer);
        print("Rigidbody collider is " + lineOfSight.collider);
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        if(lineOfSight.collider != null)
        {
            if(lineOfSight.collider.gameObject == player)
            {
                hasSightlineOnPlayer = true;
                hasAggroOnPlayer = true;
            }
            else
            {
                hasSightlineOnPlayer = false;
                rb2d.velocity -= rb2d.velocity * .75f;
            }
        }
        if (hasAggroOnPlayer)
        {
            if (hasSightlineOnPlayer)
            {
                switch (type)
                {
                    case AIType.Chase:
                        {

                            break;
                        }
                    case AIType.Cautious:
                        {
                            break;
                        }
                    case AIType.Kamikaze:
                        {
                            FaceTowardsPlayer();
                            rb2d.velocity = (VectorToPlayer.normalized) * speed;
                            break;
                        }
                }
            }
        }
        
        
    }
}
