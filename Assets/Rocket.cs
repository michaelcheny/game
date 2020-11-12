﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // get ref to rigid body
    Rigidbody rigidbody;
    // get ref to the audio source
    AudioSource audioSource;

    [SerializeField] float rcsThrust = 200f;
    [SerializeField] float mainThrust = 35f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();

    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("friendly game object collided");   
                break;
            case "Obstacle":
                audioSource.Play();
                Destroy(gameObject);
                break;
            case "Finish":
                print("Victory!");
                break;
            default:
                // audioSource.Play();
                print("dead");
                Destroy(gameObject);
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) {
            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying){
            audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true; // manual control of rotation
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        } else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidbody.freezeRotation = false;
    }
}
