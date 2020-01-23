using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eatings : MonoBehaviour
{
    public Controller player;
    public bool done = false;
    public float time = 0f;
    public bool IsTouching =false;
    public Image energybar;
    public GameObject bars;
    public HintList hint;
    public AudioSource clip;
    public TimeLimit timed;
    // Update is called once per frame
    void Update()
    {
        if (IsTouching && Input.GetKey(KeyCode.E) && !done) {
            done = true;
            StartCoroutine(eats());
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

    IEnumerator eats() {
        int i = 0;
        float bar = 0;
        player.eating = true;
        clip.Play();
        do
        {
            bar += 20;
            energybar.fillAmount = bar / 100;
            i++;
            yield return new WaitForSeconds(1);
        } while (i < 5);
        clip.Stop();
        player.eating = false;
        bars.SetActive(false);
        done = true;
        player.alrdyEat = true;
        Time.timeScale = 1;
        hint.indexP();
        timed.MaxTime();
       // hint.show();
    }
}
