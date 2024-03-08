using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManip : MonoBehaviour
{
    public const int NONE = 0, PAUSE = 1, REWIND = 2;
    static float speed = 0;
    static int mode = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        mode = Input.GetKey(KeyCode.C) ? REWIND : Input.GetKey(KeyCode.V) ? PAUSE : NONE;
    }

    public static bool ManupilatingTime()
    {
        return mode == REWIND || mode == PAUSE;
    }

    public static float GetManipIntensity()
    {
        return mode == REWIND ? 0.02f : 0;
    }


}
