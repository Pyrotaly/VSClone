using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericSave
{
    [System.Serializable]
    public class GameData 
    {
        public int playerHealth;
        //public Vector3 playerPosition;
        public SerializableDictionary<int, bool> levelCompleted;

        // the values defined in this construtor will be default values if no data to load
        public GameData()
        {
            this.playerHealth = 400;        // Starting player health
            //playerPosition = Vector3.zero;
            levelCompleted = new SerializableDictionary<int, bool>();

            levelCompleted.Add(1, true);
            levelCompleted.Add(2, false);
        }
    }
}
