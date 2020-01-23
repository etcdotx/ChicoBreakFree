using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanging : MonoBehaviour
{
    public bool pausefirst =false;
    // Start is called before the first frame update
    void Start()
    {
        if (!pausefirst)
        {
            Time.timeScale = 1;
        }
        else {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
