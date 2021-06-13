using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityCore
{
	namespace Audio
    {
		public class PauseManager : MonoBehaviour
		{

			public static PauseManager instance;
			public static bool paused;

			public GameObject pauseMenu;

			public AudioController controller;

			// init
			void Awake()
			{
				if (instance && instance != this)
				{
					Destroy(gameObject);
					return;
				}
				instance = this;
				DontDestroyOnLoad(gameObject);
			}

			// Update is called once per frame
			void Update()
			{
				// If we're in the main menu, can't pause
				if (SceneManager.GetActiveScene().buildIndex == 0)
				{
					return;
				}

				if ((Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) ||
					(Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame))
				{
					togglePause();
				}
			}

			public void togglePause()
			{
				setPaused(!paused);
			}

			public void setPaused(bool shouldBePaused)
			{
				paused = shouldBePaused;
				Time.timeScale = (paused) ? 0 : 1.0f;
				pauseMenu.SetActive(paused);
			}

			public void loadMainMenu()
			{
				setPaused(false);
				SceneManager.LoadScene(0);
				controller.PlayAudio(AudioType.Menu_ST, true);
			}
		}

	}
}
