using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bapak3 : MonoBehaviour
{
    public Controller player;
    public List<Anak3> anak2s = new List<Anak3>();
    public GameObject UISalah;
    public GameObject UIBenar1;
    public GameObject UIBenar2;
    public GameObject UIPin;
    public GameObject KunciLama;
    public AudioSource source;
    public Rigidbody rb;
    public GameObject hint;
    public HintList hinting;
    public Animator anim;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    public void CekJawaban()
    {
        bool wrong = false;
        if (anak2s[0].isi != 1) wrong = true;
        if (anak2s[1].isi != 4) wrong = true;
        if (anak2s[2].isi != 2) wrong = true;
        if (anak2s[3].isi != 1) wrong = true;
        if (wrong)
        {
            UISalah.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            UIPin.SetActive(false);
            UIBenar2.SetActive(true);
            UIBenar1.SetActive(true);
            KunciLama.SetActive(false);
            player.HaveKey33 = false;
            player.PaluGet();
            source.Play();
            rb.isKinematic = false;
            //hint.SetActive(true);
            hinting.indexP();
            anim.SetBool("Open", true);
}
    }

    public void Restisi()
    {
        foreach (Anak3 a in anak2s)
        {
            a.reset();
        }
    }
}
