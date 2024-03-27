using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime =130f; // Total time for the countdown
    private float currentTime; // Current time left
    public TextMeshProUGUI textMeshPro;

    [Header("LOSE STATE")]
    public GameObject[] levelForGame;
    public GameObject EndText;
    public GameObject TimerText;
    public Restart restartScript;
    void Start()
    {
        
        currentTime = totalTime; // Initialize current time
    }

    void Update()
    {
        // Update the timer
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Decrease the current time
            UpdateTimerDisplay();
        }
        else
        {
            // Time's up!
            currentTime = 0;
            TimesUp();
        }
    }

    void UpdateTimerDisplay()
    {
        // Update the TextMeshPro text to display the current time
        int seconds = (int)currentTime % 60;
        textMeshPro.text = seconds.ToString("D2"); // Display seconds with leading zero
    }

    void TimesUp()
    {
        EndText.SetActive(true);
        TimerText.SetActive(false);
        restartScript.enabled = true;
        Debug.Log("Time's up!"); 
        
    
        foreach (GameObject obj in levelForGame)
        {
            obj.SetActive(false);
        }
    }   
}