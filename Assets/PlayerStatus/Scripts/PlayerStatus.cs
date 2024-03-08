using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Image aurabar;
    public float auraAmount = 100f;

    public Image healthbar;
    public float healthAmount = 100f;



    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (Input.GetKey(KeyCode.LeftShift)) LoseHealth(0.3f);
            else LoseAura(0.5f);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.LeftShift)) GainHealth(0.3f);
            else GainAura(0.5f);
        }
        */

    }

    public void LoseAura(float amount)
    {
        auraAmount -= amount;
        aurabar.fillAmount = auraAmount / 100f;
    }

    public void GainAura(float amount)
    {
        auraAmount += amount;
        auraAmount = Mathf.Clamp(auraAmount, 0, 100f);
        aurabar.fillAmount = auraAmount / 100f;
    }


    public void LoseHealth(float amount)
    {
        healthAmount -= amount;
        healthbar.fillAmount = healthAmount / 100f;
    }

    public void GainHealth(float amount)
    {
        healthAmount += amount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100f);
        healthbar.fillAmount = healthAmount / 100f;
    }
}
