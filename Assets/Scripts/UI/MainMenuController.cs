using UnityEngine;

namespace QazaqCity.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject pauseMenu;

        public void StartGame()
        {
            if (mainMenu != null) mainMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void TogglePause()
        {
            bool paused = Time.timeScale > 0.01f;
            Time.timeScale = paused ? 0f : 1f;
            if (pauseMenu != null) pauseMenu.SetActive(paused);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
