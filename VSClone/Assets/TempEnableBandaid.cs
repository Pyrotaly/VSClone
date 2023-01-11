using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericSave
{
    // The DataPersisteneManager(DPM) can only get all objects having IData interface if gameObject is enabled.  
    // This script temporarily enables this gameObject for the DPM to get access to the IData objects in this object 
    // But deactivates it as originally intended
    public class TempEnableBandaid : MonoBehaviour
    {
        private void Start()
        {
            Invoke("deactivate", 0.25f);
        }

        private void deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
