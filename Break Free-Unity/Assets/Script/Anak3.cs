using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anak3 : MonoBehaviour
{
    public List<GameObject> pin = new List<GameObject>();
    public int index = 0;
    public int isi = 1;

    public void change()
    {
        pin[index].SetActive(false);
        index++;
        isi++;
        if (index > 3)
        {
            index = 0;
        }
        if (isi > 4)
        {
            isi = 1;
        }
        pin[index].SetActive(true);
    }

    public void reset()
    {
        index = 0;
        pin[0].SetActive(true);
        pin[1].SetActive(false);
        pin[2].SetActive(false);
        pin[3].SetActive(false);
        isi = 1;
    }
}

