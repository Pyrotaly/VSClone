using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSetParent : MonoBehaviour
{
    public Transform parent;
    void Start()
    {
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
        transform.SetParent(parent, true);
    }
}
