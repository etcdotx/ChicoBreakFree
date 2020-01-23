using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject UIHint;
    public bool IsTouching = false;
    public Controller player;

    private void Start()
    {
        player = FindObjectOfType<Controller>().GetComponent<Controller>();
    }

    private void Update()
    {
        if (IsTouching) {
            if (Input.GetKey(KeyCode.E) && player.alrdyEat) {
                UIHint.SetActive(true);
                player.foundclue = true;
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTouching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTouching = false;
        }
    }
}
