using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollision : MonoBehaviour
{
    public bool IsTouching = false;

    public Controller player;

    public Animator anim;
    
    public GameObject UIHint;
    public GameObject getItem;
    public GameObject target;

    public AudioSource clip;
    public AudioSource getItemSFX;
    
    public bool open =false; 
    public bool giveItem = false;
    public bool RequireItem = false;
    public bool GiveKey1 = false;
    public bool GiveKey31 = false;
    public bool GiveKey32 = false;
    public bool Key1 = false;
    public bool Key31 = false;
    public bool Key32 = false;
    public bool disable = false;
    public bool chicken = false;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    private void Update()
    {
        if (IsTouching && !open) {
            if (Input.GetKey(KeyCode.E)) {
                if (RequireItem)
                {
                    if (Key1)
                    {

                    }
                    else if (Key31)
                    {

                    }
                    else if (Key32) {

                    }
                }
                else
                {
                    if (anim != null)
                    {
                        clip.Play();
                        anim.SetBool("Open", true);
                    }
                    open = true;
                    
                }
                if (giveItem) {
                    UIHint.SetActive(true);
                    getItem.SetActive(true);
                    if (disable) target.SetActive(false);
                    if (chicken) Time.timeScale = 0;player.haveChicken = true;
                    if (GiveKey1)
                    {
                        player.Key1Get();
                    }
                    if (GiveKey31) {
                        player.Key31Get();
                    }
                    getItemSFX.Play();
                }
            }
        }
    }

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
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
}
