using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GenericPauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused;
        [SerializeField] private GameObject pauseMenuUI;

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.started && GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        private void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        private void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        // Loads the last checkpoint or save file
        public void Reload()
        {

        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void ExitToDesktop()
        {
            //Ask to save?
            Application.Quit();
        }
    }
}
