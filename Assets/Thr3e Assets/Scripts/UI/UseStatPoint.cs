using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStatPoint : MonoBehaviour {

    public PlayerStats playerStats;              // The script that pulls the stats of the player.
    public AudioClip UseStatPointClip;           // The sound effect that plays when the player levels up.
    public StatModifier statModifier;
    public PlayerInterface playerInterface;

    public void IncreaseStrength()
    {
        if (playerStats.currentStatPoints > 0)
        {
            playerStats.currentStatPoints--;
            statModifier.IncreaseBaseStrength();
            playerStats.pointsInStrength++;
            GetComponent<AudioSource>().Play();
            Debug.Log("Used a stat point to increase strength!");
        }
        else
        {
            // Do nothing because we don't have enough stat points to spend!
            Debug.Log("Not enough stat points!");
        }
    }

    public void IncreaseAgility()
    {
        if (playerStats.currentStatPoints > 0)
        {
            playerStats.currentStatPoints--;
            statModifier.IncreaseBaseAgility();
            playerStats.pointsInAgility++;
            GetComponent<AudioSource>().Play();
            Debug.Log("Used a stat point to increase agility!");
        }
        else
        {
            // Do nothing because we don't have enough stat points to spend!
            Debug.Log("Not enough stat points!");
        }
    }

    public void IncreaseHealth()
    {
        if (playerStats.currentStatPoints > 0)
        {
            playerStats.currentStatPoints--;
            statModifier.IncreaseBaseHealth();
            playerStats.pointsInHealth++;
            GetComponent<AudioSource>().Play();
            Debug.Log("Used a stat point to increase Health!");
        }
        else
        {
            // Do nothing because we don't have enough stat points to spend!
            Debug.Log("Not enough stat points!");
        }
    }

    public void IncreaseResource()
    {
        if (playerStats.currentStatPoints > 0)
        {
            playerStats.currentStatPoints--;
            statModifier.IncreaseBaseResource();
            playerStats.pointsInResource++;
            GetComponent<AudioSource>().Play();
            Debug.Log("Used a stat point to increase resource!");
        }
        else
        {
            // Do nothing because we don't have enough stat points to spend!
            Debug.Log("Not enough stat points!");
        }
    }
}
