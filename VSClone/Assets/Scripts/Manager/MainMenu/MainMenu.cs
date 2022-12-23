using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GenericMainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string newGameSceneName;
        [SerializeField] private string continueGameScene;

        public void PlayGame()
        {
            SceneManager.LoadScene("TEMP");
        }

        public void ContinueGame()
        {
            // TODO: Save feature of know where to load player
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}