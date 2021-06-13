using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour {

	private int player_index = 0;
	public static int num_inputs = 0;

	public static Vector2[] player_propels = new Vector2[] { new Vector2(), new Vector2() };


	// Start is called before the first frame update
	void Awake() {
		player_index = num_inputs % 2;
		num_inputs++;
		if (num_inputs > 2) {
			Debug.LogWarning("More than 2 inputs detected");
		}
	}

	// Update is called once per frame
	void Update() {

	}

	public void OnMove(InputAction.CallbackContext callbackContext) {
		player_propels[player_index] = callbackContext.ReadValue<Vector2>();
	}
}
