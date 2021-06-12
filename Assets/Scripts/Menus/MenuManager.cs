using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ShipType { Kayak, Tug_of_War, Magnets }


public class MenuManager : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject ShipSelect;
	public GameObject LevelSelect;

	public static ShipType currentShipType;


	// Init
	void Awake() {
		ShowMainMenu();
	}


	public void Quit() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
	}


	public void ShowMainMenu() {
		MainMenu.SetActive(true);
		ShipSelect.SetActive(false);
		LevelSelect.SetActive(false);
	}

	public void ShowShipSelect() {
		MainMenu.SetActive(false);
		ShipSelect.SetActive(true);
		LevelSelect.SetActive(false);
	}

	public void ShowLevelSelect() {
		MainMenu.SetActive(false);
		ShipSelect.SetActive(false);
		LevelSelect.SetActive(true);
	}

	// Set a certain type of ship
	public void SelectShip(int shipType) {
		currentShipType = (ShipType)shipType;
		ShowLevelSelect();
	}

	// Select a certain level to load
	public void SelectLevel(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}
}
