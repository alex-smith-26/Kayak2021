using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UnityCore
{
	namespace Audio
	{
		public class ReturnToMain : MonoBehaviour
		{

			public AudioController controller;

            private void Start()
            {
				controller = GameObject.Find("MusicPlayer").GetComponent<AudioController>();
            }

            public void loadMainMenu()
			{
				SceneManager.LoadScene(0);
				controller.PlayAudio(AudioType.Menu_ST, true);
			}
		}
	}
}

