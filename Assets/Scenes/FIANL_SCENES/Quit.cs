using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Program Ended");
        Application.Quit();
    }
}
