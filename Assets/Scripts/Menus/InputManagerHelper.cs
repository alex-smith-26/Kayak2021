using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerHelper : MonoBehaviour {

	public static InputManagerHelper instance;


	// init
	void Awake() {
		if (instance && instance != this) {
			Destroy(gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
