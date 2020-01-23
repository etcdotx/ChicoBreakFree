using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintList : MonoBehaviour
{
    public int index = 0;
    public List<GameObject> go = new List<GameObject>();

    public void show() {
        go[index].SetActive(true);
    }

    public void indexP() {
        index++;
    }

}
