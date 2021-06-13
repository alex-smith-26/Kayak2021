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

		// Find its position in the level, delete the existing ship(s), move the new one(s) there.
		GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
		bool needToReplace = true;
		Vector3 position1ToSpawn = new Vector3();
		Vector3 position2ToSpawn = new Vector3();

		if (ships.Length == 1) {
			position1ToSpawn = ships[0].transform.position;
		} else if (ships.Length == 2) {
			if (currentShipType == ShipType.Magnet) {
				needToReplace = false;
			} else {
				position1ToSpawn = ships[0].transform.position;
				position2ToSpawn = ships[1].transform.position;
			}
		} else {
			Debug.LogError("No ships found in non-main menu scene (determined by build index)");
		}

		if (needToReplace) {
			// Destroy all the existing ship(s)
			foreach (GameObject ship in ships) {
				Destroy(ship);
			}

			// Spawn the new ship(s)
			if (currentShipType == ShipType.Kayak) {
				Instantiate(kayak_prefab, position1ToSpawn, kayak_prefab.transform.rotation);
			} else if (currentShipType == ShipType.Tug_of_War) {
				Instantiate(tug_of_war_prefab, position1ToSpawn, tug_of_war_prefab.transform.rotation);
			} else if (currentShipType == ShipType.Magnet) {
				Instantiate(magnet_prefab_1, position1ToSpawn, magnet_prefab_1.transform.rotation);
				Instantiate(magnet_prefab_2, position2ToSpawn, magnet_prefab_2.transform.rotation);
			} else {
				Debug.LogError("No ship type provided for ShipType: " + currentShipType);
			}
		}
	}

}
