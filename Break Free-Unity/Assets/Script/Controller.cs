using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpforce = .5f;
    public float speedMultiplier = 1.0f;
    public Animator anim;
    private Rigidbody rb;

    public AudioSource jump;
    public AudioSource walk;
    public AudioSource sneak;

    public bool isMoving = true;
    public bool onGround = true;
    public bool eating = false;
    public bool alrdyEat = false;

    public bool behindBoxL = false;
    public bool behindBoxR = false;
    public bool disabled = false;
    public bool HaveKey1 = false;
    public bool HaveKey31 = false;
    public bool HaveKey32 = false;
    public bool HaveKey33 = false;
    public bool havePalu = false;
    public bool HaveMask = false;
    public bool haveChicken = false;
    public bool foundclue = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0 && !eating && !disabled)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                Vector3 v3 = new Vector3();
                if (Input.GetKey(KeyCode.A))
                {
                    v3 += Vector3.back;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    v3 += Vector3.forward;
                }

                if (Input.GetKey(KeyCode.W))
                {
                    v3 += Vector3.left;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    v3 += Vector3.right;
                }
                anim.SetBool("Jalan", true);
                Quaternion rotation = Quaternion.LookRotation(v3);
                transform.localRotation = rotation;

                transform.Translate(speed * speedMultiplier * Time.deltaTime * Vector3.forward);
                isMoving = true;
            }
            else
            {
                anim.SetBool("Jalan", false);
                isMoving = false;
            }

            if (onGround)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector3.up * jumpforce;
                    jump.Play();
                }
            }
        }

        if (Time.timeScale != 0)
        {
            if (isMoving && onGround)
            {
                if (speedMultiplier == 1)
                {
                    if (!walk.isPlaying)
                    {
                        walk.Play();
                        sneak.Stop();
                    }
                }
                else
                {
                    if (!sneak.isPlaying)
                    {
                        sneak.Play();
                        walk.Stop();
                    }
                }
            }
            else
            {
                walk.Stop();
                sneak.Stop();
            }
        }
        else {
            walk.Stop();
            sneak.Stop();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") {
            onGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left") {
            behindBoxL = true;
        }else if(other.tag == "Right"){
            behindBoxR = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Left")
        {
            behindBoxL = true;
        }
        else if (other.tag == "Right")
        {
            behindBoxR = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Left")
        {
            behindBoxL = false;
        }
        else if (other.tag == "Right")
        {
            behindBoxR = false;
        }
    }

    public void MaskGet() {
        HaveMask = true;
    }

    public void Key1Get() {
        HaveKey1 = true;
    }

    public void Key31Get() {
        HaveKey31 = true;
    }

    public void Key32Get() {
        HaveKey32 = true;
    }

    public void Key33Get()
    {
        HaveKey33 = true;
    }

    public void PaluGet() {
        havePalu = true;
    }
}
