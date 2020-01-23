using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDoor : MonoBehaviour
{
    public bool IsTouching = false;

    public Controller player;

    public Animator anim;
    public TimeLimit timesss;
    public GameObject UIHint;
    public bool nemurat = false;

    public AudioSource source;
    public AudioSource detik;
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
                if (player.alrdyEat && player.foundclue)
                {
                    if (!nemurat)
                    {
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
        timesss.freeze = true;
        source.Play();
        detik.Stop();
        anim.SetBool("Open", true); yield return new WaitForSeconds(3f);
        player.disabled = true;
        UIHint.SetActive(true);
    }
}
