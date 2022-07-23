using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audios;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;

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
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if(!audios.isPlaying)
            {
               audios.Play(); 
            }
        else
        {
                audios.Stop();
        }
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }


    void ApplyRotation(float rotationFrame)
    {
        rb.freezeRotation = true; // we can manually rotate
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation , ps system can take care now
    }
}
