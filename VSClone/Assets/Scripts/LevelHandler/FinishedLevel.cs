using GenericSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedLevel : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int currentLevelID = 0;
    [SerializeField] private int nextLevelID = 0;
    [SerializeField] private GenericMenuFader.SceneTransistionFader fader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hi");
            FinishLevel();
        }
    }

    public void FinishLevel()
    {
        DataPersistenceManager.instance.SaveGame();
        Invoke("AfterFinishLevel", 2);  //Afraid that saving might not be instant so add artifical load time
    }

    public void AfterFinishLevel()
    {
        fader.FadeToLevel(nextLevelID); 
    }

    public void LoadData(GameData data)
    {
        // Do nothing as all this script does is saves if a level is completed or not
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log(currentLevelID);
        if (data.levelCompleted.ContainsKey(currentLevelID))
        {
            data.levelCompleted.Remove(currentLevelID);
        }
        data.levelCompleted.Add(currentLevelID, true);
    }
}
