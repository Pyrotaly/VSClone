using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Old Script, used when transitioning between rooms like Binding of Issac
public class CameraRoomManager : MonoBehaviour
{
    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") ) //&& !collision.isTrigger
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //&& !collision.isTrigger
        {
            virtualCam.SetActive(false);
        }
    }
}
