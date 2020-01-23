using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public Image Times;
    public float CurrentTime = 30f;
    public bool notif = false;
    public GameObject cariPatung;
    public GameObject lose;
    public bool freeze = false;
    public Controller player;
    public GameObject audioKepake;
    public GameObject inventory;
    public AudioSource alarm;
    public bool audionotplayed = false;
    public bool chickenused = false;
    public AudioSource detik;
    private void Start()
    {
        player = FindObjectOfType<Controller>().GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            CurrentTime -= 1 * Time.deltaTime;
            Times.fillAmount = CurrentTime / 120f;
            if (CurrentTime < 10 && !notif && !player.eating && player.alrdyEat)
            {
                if (!player.haveChicken && !chickenused)
                {
                    notif = true;
                    cariPatung.SetActive(true);
                    Time.timeScale = 0;
                }

                if (!audionotplayed) {
                    audionotplayed = true;
                    alarm.Play();
                }
            }
            if (CurrentTime <= 0)
            {
                if (!player.haveChicken)
                {
                    lose.SetActive(true);
                    detik.Stop();
                    Time.timeScale = 0;
                }
                else {
                    player.haveChicken = false;
                    audioKepake.SetActive(true);
                    inventory.SetActive(false);
                    AddTime();
                    chickenused = true;
                    audionotplayed = false;
                    Time.timeScale = 0;
                }
            }
        }
    }

    public void MaxTime() {
        CurrentTime = 120f;
    }

    public void AddTime() {
        CurrentTime += 60f;
        if (CurrentTime > 120) {
            CurrentTime = 120;
        }
        notif = true;
    }
}
