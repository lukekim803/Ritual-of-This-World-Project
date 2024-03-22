using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : MonoBehaviour
{
    public GameObject UISTart;
    public GameObject level1;

    public Timer timeScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timeScript.enabled = true;
            level1.SetActive(true);
            UISTart.SetActive(false);
        }
    }
}
