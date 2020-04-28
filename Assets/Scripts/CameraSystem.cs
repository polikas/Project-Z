﻿using UnityEngine;
using System.Collections;

public class CameraSystem : MonoBehaviour
{
    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}
