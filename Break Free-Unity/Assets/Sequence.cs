using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    public Light light1_1;
    public Light light1_2;
    public Light light3_1;
    public Light light3_2;

    public Animator pintu;

    public Transform level2;
    public Transform level3;

    public bool ON = false;
    public bool OFF = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F4)) {
            ON = true;
        }
        if (Input.GetKey(KeyCode.F3)) {
            OFF = true;
        }
        if (Input.GetKey(KeyCode.Z)) {
            pintu.SetBool("A", true);
        }
        if (Input.GetKey(KeyCode.F1)) {
            transform.position = level2.position;
        }
        if (Input.GetKey(KeyCode.F2))
        {
            transform.position = level3.position;
        }

        if (ON) {
            if (light1_1.intensity < .5f) {
                light1_1.intensity += (.1f * Time.fixedDeltaTime);
            }
            if (light1_2.intensity < .5f)
            {
                light1_2.intensity += (.1f * Time.fixedDeltaTime);
            }
        }

        if (OFF) {
            if (light3_1.intensity > 0) {
                light3_1.intensity -= (.1f * Time.fixedDeltaTime);
            }
            if (light3_2.intensity > 0)
            {
                light3_2.intensity -= (.1f * Time.fixedDeltaTime);
            }
        }
    }
}
