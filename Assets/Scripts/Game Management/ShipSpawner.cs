using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ShipType { Kayak, Tug_of_War, Magnet }


public class ShipSpawner : MonoBehaviour {

	public static ShipSpawner instance;

	public static ShipType currentShipType;

	public GameObject kayak_prefab;
	public GameObject tug_of_war_prefab;
	public GameObject magnet_prefab_1;
	public GameObject magnet_prefab_2;


	// init
	void Awake() {
		if (instance && instance != this) {
			Destroy(gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += onSceneLoaded;
	}

	// When a scene (other than the main menu) loads, instantiate the selected ship type.
	private void onSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
		if (scene.buildIndex == 0) {
			return;
		}

		if (currentShipType == ShipType.Kayak) {
			Instantiate(kayak_prefab);
		} else if (currentShipType == ShipType.Tug_of_War) {
			Instantiate(tug_of_war_prefab);
		} else if (currentShipType == ShipType.Magnet) {
			Instantiate(magnet_prefab_1);
			Instantiate(magnet_prefab_2);
		} else {
			Debug.LogError("No ship type provided for ShipType: " + currentShipType);
		}

		// TODO - find its position in the level, delete the existing ship(s), move the new one(s) there.
	}
}
