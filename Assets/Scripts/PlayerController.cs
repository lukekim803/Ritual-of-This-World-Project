using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SerialController serialController;
    public float rollSpeed = 100f; // Adjust the speed of roll rotation
    private Queue<float> inputSamples = new Queue<float>();
    private const int averageSampleSize = 5;
    private float averageHInput = 0f;

    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    void Update()
    {
        string message = serialController.ReadSerialMessage();
        if (message == null) return;

        if (message.StartsWith("A:"))
        {
            string[] splitMessage = message.Split(';');
            string[] accelData = splitMessage[0].Split(':')[1].Split(',');

            // Parse and scale the X-axis MPU6050 value
            float ax = float.Parse(accelData[0]) / 8500; // Sensitivity (DO NOT TOUCH)

            // Update averaging 
            if (inputSamples.Count >= averageSampleSize) inputSamples.Dequeue();
            inputSamples.Enqueue(ax);

            // Calculate average input
            averageHInput = 0f;
            foreach (float input in inputSamples) averageHInput += input;
            averageHInput /= inputSamples.Count;
        }

        // Perform roll rotation based on averaged input
        float rollAngle = averageHInput * rollSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rollAngle);
    }
}