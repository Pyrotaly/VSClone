 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GenericMainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Menu Buttons")]
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueGameButton;

        [SerializeField] private string newGameSceneName;
        [SerializeField] private string continueGameScene;

        private void Start()
        {
            //if (!GenericSave.DataPersistenceManager.instance.HasGameData())
            //{
            //    continueGameButton.interactable = false;
            //}
        }

        public void PlayGame()
        {
            DisableMenuButtons();

            GenericSave.DataPersistenceManager.instance.NewGame();

            SceneManager.LoadSceneAsync(newGameSceneName);
        }

        public void ContinueGame()
        {
            DisableMenuButtons();
            // TODO: Save feature of know where to load player
            SceneManager.LoadSceneAsync("SceneP1");
        }

        // Player could click on new game button really fast and accidently cause errors calling function twice in quick succession
        private void DisableMenuButtons()
        {
            newGameButton.interactable = false;
            continueGameButton.interactable = false;
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}