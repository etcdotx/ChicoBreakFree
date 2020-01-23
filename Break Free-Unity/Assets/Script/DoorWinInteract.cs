using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWinInteract : MonoBehaviour
{
    public bool IsTouching = false;

    public Controller player;

    public Animator anim;

    public GameObject UIHint;
    public bool nemurat = false;

    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouching)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (player.HaveKey1) {
                    if (!nemurat) {
                        StartCoroutine(OpenThis());
                    }
                }
            }
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


    IEnumerator OpenThis()
    {
        source.Play();
        player.disabled = true;
        anim.SetBool("Open", true); yield return new WaitForSeconds(3f);
       
        UIHint.SetActive(true);
    }
}
