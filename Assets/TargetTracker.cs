using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{

    private GameObject[] targets;

    private int alive;

    public LevelJumper jumper;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        alive = targets.Length;
        foreach(GameObject target in targets)
        {
            target.GetComponent<VelocityDesructible>().tracker = this;
        }
    }

    public void NoteDeath()
    {
        alive--;
        if(alive <= 0)
        {
            if(jumper)
            {
                jumper.Jump2Scene();
            }
        }
    }

    
}
