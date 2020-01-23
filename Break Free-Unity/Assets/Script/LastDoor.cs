using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    public bool IsTouching = false;

    public Controller player;

    public Animator anim;
    public TimeLimit timesss;
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
                if (player.havePalu)
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
        player.disabled = true;
        UIHint.SetActive(true);
        yield return new WaitForSeconds(1);
        nemurat = true;
        Time.timeScale = 0;
    }
}
