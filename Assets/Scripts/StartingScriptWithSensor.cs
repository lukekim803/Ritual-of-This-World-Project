using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScriptWithSensor : MonoBehaviour
{
    public SerialController serialController;
    public GameObject uielement;
    public GameObject level1; 
    public Timer timeScript;
    public float pressureThreshold = 0.5f; 

    private void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    private void Update()
    {
        string message = serialController.ReadSerialMessage();
        if (message == null) return;

        if (message.StartsWith("P:"))
        {
            float pressureValue = ParsePressure(message);

            if (pressureValue >= pressureThreshold)
            {
                ActivateObjects();
                EnableScripts();
            }
        }
    }

    private float ParsePressure(string message)
    {
        string[] splitMessage = message.Split(';');
        string[] pressureData = splitMessage[0].Split(':')[1].Split(',');

        float pressure = float.Parse(pressureData[0]);
        return pressure;
    }

    private void ActivateObjects()
    {
        level1.SetActive(true);
        uielement.SetActive(false);
    }

    private void EnableScripts()
    {
        timeScript.enabled = true;
    }
}
