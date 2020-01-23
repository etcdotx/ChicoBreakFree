using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tani : MonoBehaviour
{
    public int index = 1;
    public bool revers;
    public bool left = false;
    public bool right = false;

    public List<Transform> patrolP;
    public List<AudioSource> workingAudio;
    public AudioSource walking;
    public Controller player;
    public float countdown;
    public bool starnemu = false;

    public float speed;
    public GameObject lose;
    public bool reach = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
       
    }
    private void Update()
    {
        if (!reach)
        {
            Debug.Log("going");
            if (this.transform.position.z > patrolP[index].position.z)
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * speed);


                if (this.transform.position.z <= patrolP[index].position.z)
                {
                    reach = true;
                }

            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);


                if (this.transform.position.z > patrolP[index].position.z)
                {
                    reach = true;
                }
            }
            if (right)
            {
                if (player.behindBoxR)
                {
                    countdown += 1 * Time.deltaTime;
                    if (countdown > 3)
                    {
                        lose.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
                else
                {
                    countdown = 0;
                }
            }
            else if (left)
            {
                if (player.behindBoxL)
                {
                    countdown += 1 * Time.deltaTime;
                    if (countdown > 3)
                    {
                        lose.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
                else
                {
                    countdown = 0;
                }
            }

            if (!walking.isPlaying) {
                walking.Play();
            }
        }
        else if (reach && !starnemu) {
            starnemu = true;
            StartCoroutine(Mulai());
        }
    }

    IEnumerator Mulai() {
            countdown = 0;
        walking.Stop();
            workingAudio[Random.Range(0, 1)].Play();
            yield return new WaitForSeconds(Random.Range(5, 10));
            foreach (AudioSource a in workingAudio) {
                a.Stop();
            } 
            if (!revers) {
                index++;
                if (index > 2)
                {
                    revers = true;
                    index = 1;
                    this.transform.localScale = new Vector3(1, 1, -1);
                }
            }
            else if (revers) {
                index--;
                if (index < 0)
                    revers = false;
                index = 1;
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            reach = false;
         starnemu = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left")
        {
            left= true;
        }
        else if (other.tag == "Right")
        {
            right = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Left")
        {
            left = true;
        }
        else if (other.tag == "Right")
        {
            right = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Left")
        {
            left = false;
        }
        else if (other.tag == "Right")
        {
            right = false;
        }
    }
}