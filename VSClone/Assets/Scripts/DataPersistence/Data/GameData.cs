using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericSave
{
    [System.Serializable]
    public class GameData 
    {
        public int playerHealth;
        public Vector3 playerPosition;

        // the values defined in this construtor will be default values if no data to load
        public GameData()
        {
            this.playerHealth = 400;        // Starting player health
            playerPosition = Vector3.zero;
        }
    }
}
