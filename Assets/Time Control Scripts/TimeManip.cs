using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManip : MonoBehaviour
{
    public const int NONE = 0, PAUSE = 1, REWIND = 2;
    static float speed = 0;
    static int mode = 0;

    public GameObject playerStatus;

    // Public parameters
    public float rewindRate = 0.02f;

    public float auraLossAmountOnRewind = 0.01f;
    public float auraLossAmountOnIdle = 0.001f;



    static float rewRate;

    int counter = 0; ///

    PlayerStatus playerStatusBehavior;

    void Start()
    {
        rewRate = rewindRate;
        playerStatusBehavior = playerStatus.GetComponent<PlayerStatus>();

        InvokeRepeating("loseAuraIdle", 1f, 1f);
        InvokeRepeating("clockFlag", 1f, 1f); ////////
    }



    void Update()
    {
        if(Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.V)) // Rewind
        {
            mode = REWIND;
            playerStatusBehavior.LoseAura(auraLossAmountOnRewind);
        }
        else if (Input.GetKey(KeyCode.V)) // Pause
        {
            mode = PAUSE;
        }
        else
        {
            if (Input.GetKey(KeyCode.E)) // Faster
            {
                playerStatusBehavior.LoseAura(auraLossAmountOnRewind);
            }
            mode = NONE;
        }

    }

    public void loseAuraIdle() {
        if (mode == NONE)
            playerStatusBehavior.LoseAura(auraLossAmountOnIdle);
    }

    public void clockFlag()
    {
        Debug.Log(auraLossAmountOnRewind );
    }

    public static bool ManupilatingTime() { return mode == REWIND || mode == PAUSE;}

    public static float GetManipIntensity() { return mode == REWIND ? rewRate : 0; }
}
