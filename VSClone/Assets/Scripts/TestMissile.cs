using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMissile : MonoBehaviour
{
    private void AnimationDone()
    {
        Destroy(transform.parent.gameObject);
    }
}
