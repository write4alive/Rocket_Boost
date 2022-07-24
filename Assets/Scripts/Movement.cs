using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audios;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem left_booster_particle;
    [SerializeField] ParticleSystem right_booster_particle;
    [SerializeField] ParticleSystem center_booster_particle;

    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
       rb =  GetComponent<Rigidbody>();
       audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTrust();
        ProcessRotation();
    }

    void ProcessTrust()
    {   
       if(Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }

    private void StopThrust()
    {
        audios.Stop();
        center_booster_particle.Stop();
    }

    private void StartThrust()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audios.isPlaying)
        {
            audios.PlayOneShot(mainEngine);
        }

        if (!center_booster_particle.isPlaying)
        {
            center_booster_particle.Play();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }

        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

        else
        {
            StopParticalEffects();
        }
    }

    private void StopParticalEffects()
    {
        right_booster_particle.Stop();
        left_booster_particle.Stop();
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!left_booster_particle.isPlaying)
        {
            left_booster_particle.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!right_booster_particle.isPlaying)
        {
            right_booster_particle.Play();
        }
    }

    void ApplyRotation(float rotationFrame)
    {
        rb.freezeRotation = true; // we can manually rotate
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation , ps system can take care now
    }
}
