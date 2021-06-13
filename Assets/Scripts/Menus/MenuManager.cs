using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityCore
{
	namespace Audio
    {
		public class MenuManager : MonoBehaviour
		{

			public GameObject MainMenu;
			public GameObject ShipSelect;
			public GameObject LevelSelect;
			public GameObject Credits;

			public AudioController controller;

			// Init
			void Awake()
			{
				ShowMainMenu();
				controller = GameObject.Find("MusicPlayer").GetComponent<AudioController>();
			}


			public void Quit()
			{
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
			}


			public void ShowMainMenu()
			{
				MainMenu.SetActive(true);
				ShipSelect.SetActive(false);
				LevelSelect.SetActive(false);
				Credits.SetActive(false);
			}

			public void ShowShipSelect()
			{
				MainMenu.SetActive(false);
				ShipSelect.SetActive(true);
				LevelSelect.SetActive(false);
				Credits.SetActive(false);
			}

			public void ShowLevelSelect()
			{
				MainMenu.SetActive(false);
				ShipSelect.SetActive(false);
				LevelSelect.SetActive(true);
				Credits.SetActive(false);
			}

			public void ShowCredits()
			{
				MainMenu.SetActive(false);
				ShipSelect.SetActive(false);
				LevelSelect.SetActive(false);
				Credits.SetActive(true);
			}

			// Set a certain type of ship
			public void SelectShip(int shipType)
			{
				ShipSpawner.currentShipType = (ShipType)shipType;
				ShowLevelSelect();
			}

			// Select a certain level to load
			public void SelectLevel(int sceneIndex)
			{
				SceneManager.LoadScene(sceneIndex);
				controller.PlayAudio(AudioType.Gameplay_ST, true);
			}
			public void SelectLevel(string sceneName)
			{
				SceneManager.LoadScene(sceneName);
				controller.PlayAudio(AudioType.Gameplay_ST, true);
			}
		}

	}
}
