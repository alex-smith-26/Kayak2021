using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotKillPlz : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
