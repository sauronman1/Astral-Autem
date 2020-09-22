using UnityEngine;

namespace FG {
	public class StartMenu : MonoBehaviour
	{
		private void Awake()
		{
			PauseGame();
		}

		public void PauseGame()
		{
			Time.timeScale = 0;
		}

		public void StartGame()
		{
			Time.timeScale = 1;
		}
	}
}
