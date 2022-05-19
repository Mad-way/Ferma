using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public Joystick joystick;
    public float speed = 15f;
    public Rigidbody rb;


    //private float vertical;
    void Update()
    {
        GetMobileInput();
    }

    private void GetMobileInput()
    {
        //vertical = joystick.Vertical;
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce((transform.forward * speed)/Time.deltaTime);
            //rb.AddForce(transform.forward * speed);
            //transform.localPosition += transform.forward * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-(transform.forward * speed) / Time.deltaTime);
            
        }
    }

    //Воспроизводить звук трактора
    public void PlayAudio(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    //Не воспроизводить звук трактора
    public void NoPlayAudio(AudioClip clip)
    {
        GetComponent<AudioSource>().Stop();
    }

}