using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    
    Rigidbody playerRigidbody;
    AudioSource audioSource;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        playerRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if(!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            RotatePlayer(rotationThrust, leftThrusterParticles);
        }
        else if(Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            RotatePlayer(-rotationThrust, rightThrusterParticles);
        }
        else
        {
            rightThrusterParticles.Stop();
            leftThrusterParticles.Stop();
        }
    }

    void RotatePlayer(float rotationTh, ParticleSystem particle) 
        {
            ApplyRotation(rotationTh);
            if(!particle.isPlaying)
            {
                particle.Play();
            }
        }

    void ApplyRotation(float rotationThisFrame)
    {
        playerRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        playerRigidbody.freezeRotation = false;
    }
}
