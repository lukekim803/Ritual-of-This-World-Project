using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialUiSTart : MonoBehaviour
{
    public float tiltSpeed = 50f; // Adjust this to control the tilt speed
    private float currentTilt = 0f; // Current accumulated tilt amount

    // Reference to the SerialController component
    public SerialController serialController;

    void Start()
    {
        // Get the SerialController component attached to this object
        serialController = GetComponent<SerialController>();
    }

    void Update()
    {
        // Read the latest message
        string message = serialController.ReadSerialMessage();

        // If the message is null or empty, don't process it
        if (string.IsNullOrEmpty(message))
            return;

        // Assuming the message is a float representing the X-axis gyro value
        if (float.TryParse(message, out float gyroXValue))
        {
            // Use the gyro X value directly to tilt the object, adjusting by tiltSpeed
            TiltObject(gyroXValue * tiltSpeed);
        }
    }

    void TiltObject(float tiltAmount)
    {
        // Apply the tilt amount directly since it's already in the desired range (-1 to 1)
        currentTilt += tiltAmount * Time.deltaTime;

        // Clamp the tilt to prevent full rotation if needed
        currentTilt = Mathf.Clamp(currentTilt, -90f, 90f); // Adjust the clamp range as needed

        // Apply the accumulated tilt to the GameObject
        Quaternion targetRotation = Quaternion.Euler(0, 0, currentTilt);
        transform.rotation = targetRotation;
    }
}
