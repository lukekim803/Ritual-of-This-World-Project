using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    public float tiltSpeed = 50f; // Adjust this to control the tilt speed
    private float currentTilt = 0f; // Current accumulated tilt amount
    public Gyroscope gyroScope;

    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // Check for input to tilt left
        if (Input.GetKey(KeyCode.A))
        {
            TiltObject(-1);
        }

        // Check for input to tilt right
        if (Input.GetKey(KeyCode.D))
        {
            TiltObject(1);
        }
    }

    void TiltObject(float direction)
    {
        // Calculate the amount of tilt based on the direction and speed
        float tiltAmount = direction * tiltSpeed * Time.deltaTime;

        // Accumulate the tilt amount
        currentTilt += tiltAmount;

        // Apply the accumulated tilt to the GameObject
        Quaternion targetRotation = Quaternion.Euler(0, 0, currentTilt);
        transform.rotation = targetRotation;
    }
}