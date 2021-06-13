using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KayakEndGoal : MonoBehaviour
{
    [SerializeField] public string nextLevel;
    public bool hitGoal = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ship")
        {
            if (!hitGoal)
            {
                hitGoal = true;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                StartCoroutine("NextLevelScene");
                print("level goal");
            }
        }
    }

    IEnumerator NextLevelScene()
    {
        print("loading level " + nextLevel);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextLevel);
        print("loaded " + nextLevel);
    }
}
