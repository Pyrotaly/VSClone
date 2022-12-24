using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericSave
{
    public interface IDataPersistence
    {
        void LoadData(GameData data);
        void SaveData(ref GameData data);   //Let implementing script to modify data
    }
}
