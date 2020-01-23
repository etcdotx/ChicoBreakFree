using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
    public Controller player;
    public bool IsTouching = false;
    public GameObject UI;
    public bool K31;
    public bool K32;
    public bool K33;
    public AudioSource source;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (K31)
        {
            if (IsTouching && player.HaveKey31 && Input.GetKey(KeyCode.E))
            {
                UI.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (K32)
        {
            if (IsTouching && player.HaveKey32 && Input.GetKey(KeyCode.E))
            {
                UI.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (K33)
        {
            if (IsTouching && player.HaveKey33 && Input.GetKey(KeyCode.E))
            {
                UI.SetActive(true);
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
