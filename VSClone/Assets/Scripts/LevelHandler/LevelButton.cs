using GenericSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, GenericSave.IDataPersistence
{
    [SerializeField] GenericMenuFader.SceneTransistionFader fader;

    [SerializeField] private Button button;
    public int idNumber;
    public bool completed;

    // If button is pressed, transition to level corresponding to the button's idNumber
    public void GoToLevel()
    {
        fader.FadeToLevel(idNumber);
    }

    public void LoadData(GameData data)
    {
        Debug.Log("AGH");


        data.levelCompleted.TryGetValue(idNumber, out completed);

        Debug.Log(completed);

        if (!completed)
        {
            button.interactable = false;
        }
    }

    public void SaveData(ref GameData data)
    {
        // Do nothing as currently, FinishedLevelScript saves if a certain level is completed
    }
}
