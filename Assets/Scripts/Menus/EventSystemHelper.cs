using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemHelper : MonoBehaviour {

	public static EventSystemHelper instance;


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
