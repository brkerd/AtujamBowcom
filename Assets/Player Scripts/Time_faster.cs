using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_faster : MonoBehaviour
{
    public float fasterFactor = 1.5f;
    public float fasterLength = 2f;
    
    void Update()
    {
       Time.timeScale += fasterLength * Time.unscaledDeltaTime;
       Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f); 
    }

    public void Faster()
    {
        Time.timeScale = fasterFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}

    
  
