using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToWin : MonoBehaviour
{
    public Color fillColor = Color.red; 
    public string playerTag = "Player"; 

    private SpriteRenderer spriteRenderer; 

    void Start()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag(playerTag))
        {
          
            FillColor();
        }
    }

    void FillColor()
    {
       
        spriteRenderer.color = fillColor;
    }
}
