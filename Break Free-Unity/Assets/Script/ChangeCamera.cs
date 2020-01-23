using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject cameraOn;
    public GameObject cameraOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            cameraOn.SetActive(true);
            cameraOff.SetActive(false);
        }
    }

}
