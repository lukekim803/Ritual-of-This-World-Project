using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptforEnd : MonoBehaviour
{
    public int objectCount;
    public int objectNeeded;

    [Header("Levels")]
    public GameObject CurrentLevel;
    public Timer timeScript;
    public GameObject winText;
    public GameObject winCircle;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ObjectToTurnRed"))
        {
            other.enabled = false;

            objectCount++;
        }
    }

    void Update()
    {
        if(objectCount >= objectNeeded)
        {
            timeScript.enabled = false;
            winCircle.SetActive(true);
            winText.SetActive(true);
            CurrentLevel.SetActive(false);
            //Action
        }
    }
    
}
