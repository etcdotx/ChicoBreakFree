using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskArea : MonoBehaviour
{
    public bool IsTouching = false;

    public Controller player;

    public float countdown = 0;

    public GameObject loseMenu;

    public AudioSource source;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouching) {
            if (!player.HaveMask)
            {
                countdown += 1 * Time.deltaTime;
            }
            else {
                countdown = 0;
            }
        }
        else {
            countdown = 0;
        }

        if (countdown > 3) {
            source.Stop();
            Time.timeScale = 0;
            loseMenu.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTouching = true;
            player.speedMultiplier = .5f;
            source.volume = 1f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTouching = true;
            player.speedMultiplier = .5f;
            source.volume = 1f;
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTouching = false;
            player.speedMultiplier = 1f;
            source.volume = .5f;
        }
    }
}
