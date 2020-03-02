using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCameras : MonoBehaviour
{
    public GameObject cameraEnabled;
    public GameObject cameraDisabled;

    public bool camOn = false;
    public int cameraNumber;

    void Start()
    {
        cameraNumber = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraDisabled.SetActive(false);
            cameraEnabled.SetActive(true);
        }
    }
}
