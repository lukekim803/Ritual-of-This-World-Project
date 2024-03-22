using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    public int objectCount;
    public int objectNeeded;

    [Header("Levels")]
    public GameObject CurrentLevel;
    public GameObject NextLevel;

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
            CurrentLevel.SetActive(false);
            NextLevel.SetActive(true);
        }
    }
    
}
