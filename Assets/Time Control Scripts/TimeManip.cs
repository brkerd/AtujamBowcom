using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManip : MonoBehaviour
{
    public const int NONE = 0, PAUSE = 1, REWIND = 2;
    static float speed = 0;
    static int mode = 0;

    public GameObject playerStatus;
    public float rewindRate = 0.02f;
    static float rewRate;

    void Start()
    {
        rewRate = rewindRate;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.C)) // Rewind
        {
            mode = REWIND;
            playerStatus.GetComponent<PlayerStatus>().LoseAura(0.1f);
        }
        else if (Input.GetKey(KeyCode.V)) // Pause
        {
            mode = PAUSE;
        }
        else
        {
            mode = NONE;
        }

    }

    public static bool ManupilatingTime()
    {
        return mode == REWIND || mode == PAUSE;
    }

    public static float GetManipIntensity()
    {
        return mode == REWIND ? rewRate : 0;
    }


}
