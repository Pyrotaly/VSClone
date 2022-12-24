using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace GenericSave
{
    public class DataPersistenceManager : MonoBehaviour
    {
        private GameData gameData;
        private List<IDataPersistence> dataPersistenceObjects;

        public static DataPersistenceManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one DTM");
            }
            instance = this;
        }

        private void Start()
        {
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        public void NewGame()
        {
            this.gameData = new GameData();
        }

        public void LoadGame()
        {
            // TODO - Load any saved data
            // if no data, initilize new game
            if (this.gameData == null)
            {
                Debug.Log("No data was found, making new game with defaults");
                NewGame();
            }

            // TODO - Push loaded data to all other scripts that need it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
            }

            Debug.Log("Player Health = " + gameData.playerHealth);
        }

        public void SaveGame()
        {
            // TODO - pass data to other scripts
            // TODO - save data to a file with data handler
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
                .OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }
    }
}
