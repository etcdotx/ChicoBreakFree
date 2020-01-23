using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bapak2 : MonoBehaviour
{
    public Controller player;
    public List<Anak2> anak2s = new List<Anak2>();
    public GameObject UISalah;
    public GameObject UIBenar1;
    public GameObject UIBenar2;
    public GameObject UIPin;
    public GameObject KunciLama;
    public AudioSource source;
    public Animator anim;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    public void CekJawaban() {
        bool wrong = false;
        if (anak2s[0].isi != 1) wrong = true;
        if (anak2s[1].isi != 3) wrong = true;
        if (anak2s[2].isi != 3) wrong = true;
        if (anak2s[3].isi != 3) wrong = true;
        if (anak2s[4].isi != 1) wrong = true;
        if (wrong)
        {
            UISalah.SetActive(true);
        }
        else {
            Time.timeScale = 1;
            UIPin.SetActive(false);
            UIBenar2.SetActive(true);
            UIBenar1.SetActive(true);
            KunciLama.SetActive(false);
            player.HaveKey32 = false;
            player.Key33Get();
            source.Play();
            anim.SetBool("Open", true);
        }
    }

    public void Restisi() {
        foreach (Anak2 a in anak2s) {
            a.reset();
        }
    }

}
