using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_COPY : MonoBehaviour
{
    public bool hasAggroOnPlayer = false;
    public bool hasSightlineOnPlayer = false;
    public GameObject[] nodes;
    private GameObject nextNode;
    private GameObject[] players = new GameObject[0];
    private GameObject current_target_player;
    [SerializeField] public enum AIType {Chase, Kamikaze, Cautious, Patrol};
    public AIType type;
    public float rotationSpeed;
    public float speed;
    private Rigidbody2D rb2d;
    private Vector2 desiredPosition;
    int nodeIndex = 0;

    void FaceTowards(GameObject go)
    {
        float angleToTarget = Vector2.SignedAngle(new Vector2(0, 1), (go.transform.position - transform.position));
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
        // first clear any invalid ships from the list
        List<GameObject> ships_to_keep = new List<GameObject>();
        for (int i=0; i < players.Length; i++) {
            if (players[i]) {
                ships_to_keep.Add(players[i]);
			}
		}
        players = ships_to_keep.ToArray();

        // If it's empty, find the ships
        if (players.Length == 0) {
            players = GameObject.FindGameObjectsWithTag("Ship");
            if (players.Length == 0) {
                Debug.LogError("Can't find a Ship in the scene");
                return;
			}
		}

        hasSightlineOnPlayer = false;

        if (current_target_player) {
            try_to_find_player(current_target_player);
		}

        if (!hasSightlineOnPlayer) {
            current_target_player = null;
            foreach (GameObject player in players) {
                bool found = try_to_find_player(player);
                if (found) {
                    break;
				}
            }
        }

        if (!hasSightlineOnPlayer) {
            rb2d.velocity -= rb2d.velocity * .75f;
        }

        if (hasAggroOnPlayer) {
            if (hasSightlineOnPlayer) {
                switch (type) {
                    case AIType.Chase: {
                            break;
                        }
                    case AIType.Cautious: {
                            break;
                        }
                    case AIType.Kamikaze: {
                            FaceTowards(current_target_player);
                            rb2d.velocity = ((current_target_player.transform.position - transform.position).normalized) * speed;
                            break;
                        }
                    case AIType.Patrol: {
                            FaceTowards(current_target_player);
                            rb2d.velocity = ((current_target_player.transform.position - transform.position).normalized) * speed;
                            break;
                        }
                }
            }
        } else {
            if (type == AIType.Patrol) {
                Vector2 nodePos2 = new Vector2(nextNode.transform.position.x, nextNode.transform.position.y);
                Vector2 Pos2 = new Vector2(transform.position.x, transform.position.y);
                if ((Pos2 - nodePos2).magnitude > 0.05) {
                    FaceTowards(nextNode);
                    rb2d.velocity = (nodePos2 - Pos2).normalized * speed;
                } else {
                    nodeIndex++;
                    if (nodeIndex == nodes.Length) {
                        nodeIndex = 0;
                    }
                    nextNode = nodes[nodeIndex];
                }
            }
        }
    }

    // Raycasts for the given player. Aggros on them and returns true iff found. 
    private bool try_to_find_player(GameObject player) {
        RaycastHit2D lineOfSight = Physics2D.Raycast(transform.position, (player.transform.position - transform.position));
        //Debug.DrawLine(transform.position, player.transform.position, Color.red);
        if (lineOfSight.collider != null) {
            if (lineOfSight.collider.gameObject == player) {
                hasSightlineOnPlayer = true;
                hasAggroOnPlayer = true;
                current_target_player = player;
                return true;
            } else {
                //hasSightlineOnPlayer = false;
                //rb2d.velocity -= rb2d.velocity * .75f;
            }
        }
        return false;
    }
}
