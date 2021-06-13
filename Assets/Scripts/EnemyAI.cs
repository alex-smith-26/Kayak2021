using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool hasAggroOnPlayer = false;
    public bool hasSightlineOnPlayer = false;
    public GameObject[] nodes;
    private GameObject nextNode;
    public GameObject player;
    [SerializeField] public enum AIType {Chase, Kamikaze, Cautious, Patrol};
    [SerializeField] public GameObject bullet;
    public AIType type;
    public float rotationSpeed;
    public float speed;
    private Rigidbody2D rb2d;
    private Vector2 desiredPosition;
    private Vector2 lastKnownPlayerLoc;
    int nodeIndex = 0;
    public float fireCooldown = 0.75f;
    public float fire = 0f;
    Vector2 dummy;

    void FaceTowards(GameObject go)
    {
        // Convert the vector between enemy and desired target to a signed angle
        float angleToTarget = Vector2.SignedAngle(new Vector2(0, 1), (go.transform.position - transform.position));
        // Sanity check - make sure the angle through which the enemy will rotate is less than 180 degrees
        if (Mathf.Abs(rb2d.rotation - angleToTarget) < 180)
        {
            rb2d.rotation -= (rb2d.rotation - angleToTarget) * (rotationSpeed / 100);
        }
        else if (rb2d.rotation - angleToTarget < -180)
        {
            rb2d.rotation -= (360 + (rb2d.rotation - angleToTarget)) * (rotationSpeed / 100);
        }
        else if (rb2d.rotation - angleToTarget > 180)
        {
            rb2d.rotation -= (rb2d.rotation - (angleToTarget + 360)) * (rotationSpeed / 100);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(nodes.Length > 0)
        {
            nextNode = nodes[0];
        }
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for LOS to the player's position
        RaycastHit2D lineOfSight = Physics2D.Raycast(transform.position, (player.transform.position-transform.position));
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        if(lineOfSight.collider != null)
        {
            // If player is visible, change boolean flags to match and update player's last known location
            if(lineOfSight.collider.gameObject == player)
            {
                hasSightlineOnPlayer = true;
                hasAggroOnPlayer = true;
                lastKnownPlayerLoc = player.transform.position;
            }
            // If player can't be seen, change boolean flag and bring enemy to a stop
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
                            FaceTowards(player);
                            rb2d.velocity = -((transform.position - player.transform.position).normalized) * speed;
                            break;
                        }
                    case AIType.Cautious:
                        {

                            break;
                        }
                    case AIType.Kamikaze:
                        {
                            FaceTowards(player);
                            rb2d.velocity = -((transform.position - player.transform.position).normalized) * speed;
                            break;
                        }
                    case AIType.Patrol:
                        {
                            FaceTowards(player);
                            rb2d.velocity = -((transform.position - player.transform.position).normalized) * speed;
                            break;
                        }
                }
                if (Time.time > fire)
                {
                    fire = Time.time + fireCooldown;
                    GameObject newbullet = Instantiate(bullet, transform.position + (transform.up.normalized), Quaternion.identity);
                    newbullet.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
                }
            }
            /*else
            {
                if(type == AIType.Chase)
                {
                    Vector2 pos2 = new Vector2(transform.position.x, transform.position.y);
                    Vector2 node2 = new Vector2(nextNode.transform.position.x, nextNode.transform.position.y);
                    
                    if ((dummy-lastKnownPlayerLoc).magnitude > 0)
                    {
                        float nearestDist = -1.0f;
                        foreach (GameObject i in nodes)
                        {
                            Vector2 i2 = new Vector2(i.transform.position.x, i.transform.position.y);
                            Vector2 v2 = new Vector2(transform.position.x, transform.position.y);
                            RaycastHit2D foo = Physics2D.Raycast(lastKnownPlayerLoc, (i2-lastKnownPlayerLoc).normalized, (i2-lastKnownPlayerLoc).magnitude);
                            if (foo.collider == i)
                            {
                                print("found a node that sees LKPL at ");
                                if (nearestDist < 0 || (lastKnownPlayerLoc - i2).magnitude < nearestDist)
                                {
                                    RaycastHit2D bar = Physics2D.Raycast(i.transform.position, (v2 - i2).normalized, (v2 - i2).magnitude);
                                    if (bar.collider == gameObject)
                                    {
                                        nextNode = i;
                                        dummy = lastKnownPlayerLoc;
                                        print("nextnode updated to location " + nextNode.transform.position.x + " " + nextNode.transform.position.y);
                                    }
                                }
                            }
                        }
                    }
                    
                    rb2d.velocity = -((pos2-node2).normalized) * speed;
                }
            }*/
        }
        else
        {
            // Default behavior when not in combat - only defined for Patrol-type enemies
            if(type == AIType.Patrol)
            {
                Vector2 nodePos2 = new Vector2(nextNode.transform.position.x, nextNode.transform.position.y);
                Vector2 Pos2 = new Vector2(transform.position.x, transform.position.y);
                
                if ((Pos2-nodePos2).magnitude > 0.05)
                {
                    FaceTowards(nextNode);
                    rb2d.velocity = (nodePos2 - Pos2).normalized * speed;
                }
                // When the target node is reached, change destination to the next one in the list
                else
                {
                    nodeIndex++;
                    if (nodeIndex == nodes.Length)
                    {
                        nodeIndex = 0;
                    }
                    nextNode = nodes[nodeIndex];
                }
            }
        }
        
        
    }
}
