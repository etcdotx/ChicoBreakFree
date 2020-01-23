using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bapak : MonoBehaviour
{
    public List<Anak> anak = new List<Anak>();
    public GameObject jarum;
    public GameObject UISalah;
    public GameObject UIBenar1;
    public GameObject UIBenar2;
    public GameObject UIPin;
    public Anak target;
    public int index;
    public RectTransform jarumtransform;
    public GameObject KunciLama;
    public Controller player;
    public AudioSource source;
    public Animator anim;
    private void Start()
    {
        jarumtransform = jarum.GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }
    public void resetisi() {
        jarumtransform.rotation = new Quaternion(0, 0, 0,0);
        foreach (Anak b in anak) {
            b.isi = 0;
        }
        index = 0;
        target = anak[0];
    }

    public void Record(Anak aim) {
        target = aim;
        target.isi = index;
    }

    public void muterjarum() {
        index++;
        if (index >= 10) {
            index = 0;
        }
        target.isi = index;
        Color temp = target.GetComponent<Image>().color;
        temp.a = 1f;
        target.GetComponent<Image>().color = temp;
        Debug.Log(jarumtransform.rotation.z);
        jarumtransform.Rotate(0, 0, jarumtransform.rotation.z - 36f);
        
    }

    public void kuncijawab() {
        bool wrong = false;
        if (anak[0].isi != 3) wrong = true;
        if (anak[1].isi != 2) wrong = true;
        if (anak[2].isi != 3) wrong = true;
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
            player.HaveKey31 = false;
            player.Key32Get();
            source.Play();
            anim.SetBool("Open", true);

        }
    }

}
