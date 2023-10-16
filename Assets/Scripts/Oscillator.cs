using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;  // Continuouly growing over time

        const float tau = Mathf.PI * 2;  // Constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau);  // Going from -1 to 1 
                                                     //  Sin(float f) -- here f is the input angle, in radians

        movementFactor = (rawSinWave + 1f) / 2f; // Reclaculated to go from 0 to 1 so its cleaner
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
