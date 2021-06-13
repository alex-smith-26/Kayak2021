using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject ShipSelect;
	public GameObject LevelSelect;
	public GameObject Credits;


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
		Credits.SetActive(false);
	}

	public void ShowShipSelect() {
		MainMenu.SetActive(false);
		ShipSelect.SetActive(true);
		LevelSelect.SetActive(false);
		Credits.SetActive(false);
	}

	public void ShowLevelSelect() {
		MainMenu.SetActive(false);
		ShipSelect.SetActive(false);
		LevelSelect.SetActive(true);
		Credits.SetActive(false);
	}

	public void ShowCredits() {
		MainMenu.SetActive(false);
		ShipSelect.SetActive(false);
		LevelSelect.SetActive(false);
		Credits.SetActive(true);
	}

	// Set a certain type of ship
	public void SelectShip(int shipType) {
		ShipSpawner.currentShipType = (ShipType)shipType;
		ShowLevelSelect();
	}

	// Select a certain level to load
	public void SelectLevel(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}
	public void SelectLevel(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
