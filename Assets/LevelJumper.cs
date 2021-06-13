using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelJumper : MonoBehaviour
{

    public string TargetScene;

    // Start is called before the first frame update
    void Start()
    {
        if(TargetScene == "")
        {
            Debug.LogError("PLEASE PROVIDE A SCENE TO MOVE TO");
        }
    }

    public void Jump2Scene()
    {
        StartCoroutine(NextLevel());
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(TargetScene);
    }
}
