using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Rocket : MonoBehaviour
{
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
    
    void LaunchRocket()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up);
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
        _rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,0,0.125f));
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0 , -0.125f));
        }
        _rigidbody.freezeRotation = false;
    }
}
