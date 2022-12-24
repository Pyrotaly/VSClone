using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericSave
{
    [System.Serializable]
    public class GameData : MonoBehaviour
    {
        public int playerHealth;

        public GameData()
        {
            this.playerHealth = 0;
        }
    }
}
