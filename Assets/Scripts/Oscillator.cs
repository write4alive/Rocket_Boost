using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;


    void Start()
    {
        startingPos  = transform.position;
       // Debug.Log(startingPos);
    }


    void Update()
    {
        if(period <= Mathf.Epsilon ) {return;}  // to avoid vector Nan,nan,nan epsilon is the smallest f number.

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2 ;
        float rawSinWave = Mathf.Sin(cycles *tau);
       // Debug.Log(rawSinWave);

        movementFactor = (rawSinWave + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
