using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UseHealPot : MonoBehaviour
{
    public Slider healthSlider;              // The player's health slider.
    public float refillSpeed = 0.2f;         // The refill speed of the potion.
    public int restoreAmount = 50;           // How much health the potion should restore.
    public bool refilling;                   // Bool to activate the healing.
    public int ticksRefilled = 0;            // How much health refilled by using this health potion.
    public float currCountdownValue;         // How long to wait until the next health potion can be used.
    public PlayerInterface playerInterface;  // Script to access the player's current health value.
    public const int refillTicks = 50;

    // Use this for initialization
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        ticksRefilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (refilling)
        {
            healthSlider.value += (restoreAmount / refillTicks);
            playerInterface.currentHealth = Convert.ToInt32(healthSlider.value);

            ticksRefilled++;
            //Debug.Log(ticksRefilled);
            //Debug.Log(healthSlider.value);

            if (ticksRefilled >= refillTicks)
            {
                refilling = false;
                ticksRefilled = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && healthSlider.value < healthSlider.maxValue && currCountdownValue <= 0f)
        {
            refilling = true;
            StartCoroutine(StartCountdown());
            Debug.Log("Using health potion!");
        }
        else if (Input.GetKeyDown(KeyCode.Q) && healthSlider.value == healthSlider.maxValue)
        {
            Debug.Log("Can't use health potion at full health!");
        }
        else if (Input.GetKeyDown(KeyCode.Q) && healthSlider.value != healthSlider.maxValue && currCountdownValue > 0f)
        {
            Debug.Log("You have to wait " + currCountdownValue + " seconds to use another potion!");
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 30)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }
}
