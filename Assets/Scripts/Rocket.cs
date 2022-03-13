using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 300f;
    [SerializeField] private float flySpeed = 10f;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody.mass = 0.7f;
        _rigidbody.drag = 1.0f;
    }

    void Update()
    {
        LaunchRocket();
        RotateRocket();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly" : 
                print("this friendly");
                break;
            case "Battery" : 
                print("PlusEnergy");
                break;
            default:
                print("boom!");
                break;
        }
    }

    void LaunchRocket()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(new Vector3(0,0.125f, 0) * flySpeed);
            if (!_audioSource.isPlaying)
            {
                _audioSource.volume = 0.15f;
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Pause();
        }
    }
    
    void RotateRocket()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;
        _rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,0,0.125f) * rotationSpeed);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0 , -0.125f) * rotationSpeed);
        }
        _rigidbody.freezeRotation = false;
    }
}
