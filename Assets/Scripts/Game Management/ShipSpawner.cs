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

	private const float DEFAULT_RESET_TIME = 3.5f;
	private float resetTimeRemaining = DEFAULT_RESET_TIME;


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
		Vector3 positionToSpawn = new Vector3();

		if (ships.Length == 1) {
			positionToSpawn = ships[0].transform.position;
		} else if (ships.Length == 2) {
			if (currentShipType == ShipType.Magnet) {
				needToReplace = false;
			} else {
				positionToSpawn = ships[0].transform.position;
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
				Instantiate(kayak_prefab, positionToSpawn, kayak_prefab.transform.rotation);
			} else if (currentShipType == ShipType.Tug_of_War) {
				Instantiate(tug_of_war_prefab, positionToSpawn, tug_of_war_prefab.transform.rotation);
			} else if (currentShipType == ShipType.Magnet) {
				Vector3 offset = new Vector3(0.5f, -0.2f, 0);
				Instantiate(magnet_prefab_1, positionToSpawn - offset, magnet_prefab_1.transform.rotation);
				Instantiate(magnet_prefab_2, positionToSpawn + offset, magnet_prefab_2.transform.rotation);
			} else {
				Debug.LogError("No ship type provided for ShipType: " + currentShipType);
			}
		}
	}

	// Every frame, check how many ships there are.
	private void Update() {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			return;
		}

		GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
		if ((currentShipType == ShipType.Magnet && ships.Length < 2) ||
			(currentShipType != ShipType.Magnet && ships.Length < 1)) {
			resetTimeRemaining -= Time.deltaTime;
			if (resetTimeRemaining <= 0) {
				resetLevel();
			}
		}
	}

	// Resets the level by reloading the scene
	private void resetLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		resetTimeRemaining = DEFAULT_RESET_TIME;
	}
}
