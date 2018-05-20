using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStatPoint : MonoBehaviour {

    public PlayerStats playerStats;              // The script that pulls the stats of the player.
    public AudioClip UseStatPointClip;           // The sound effect that plays when the player levels up.

    public void SpendStatPoint()
    {
        if (playerStats.currentStatPoints >= 1)
        {
            playerStats.currentStatPoints -= 1;
            GetComponent<AudioSource>().Play();
            Debug.Log("Used a stat point!");
        }
        else
        {
            Debug.Log("You don't have any stat points available!");
        }
    }

    public void SpendSkillPoint()
    {
        if (playerStats.currentStatPoints >= 1)
        {
            playerStats.currentStatPoints -= 1;
            GetComponent<AudioSource>().Play();
            Debug.Log("Used a skill point!");
        }
        else
        {
            Debug.Log("You don't have any skill points available!");
        }
    }

    public void IncreaseStrength()
    {
        if (playerStats.currentSkillPoints >= 1)
        {
            playerStats.currentSkillPoints -= 1;
            playerStats.statModifier.baseStrength++;
            Debug.Log("Used a stat point to increase strength!");
        }
        else
        {
            // Do nothing, because we have no skill points to spend.
        }
    }

    public void IncreaseAgility()
    {
        if (playerStats.currentSkillPoints >= 1)
        {
            playerStats.currentSkillPoints -= 1;
            playerStats.statModifier.baseAgility++;
            Debug.Log("Used a stat point to increase agility!");
        }
        else
        {
            // Do nothing, because we have no stat points to spend.
        }
    }

    public void IncreaseHealth()
    {
        if (playerStats.currentSkillPoints >= 1)
        {
            playerStats.currentSkillPoints -= 1;
            playerStats.statModifier.baseHealth++;
            Debug.Log("Used a stat point to increase health!");
        }
        else
        {
            // Do nothing, because we have no stat points to spend.
        }
    }

    public void IncreaseResource()
    {
        if (playerStats.currentSkillPoints >= 1)
        {
            playerStats.currentSkillPoints -= 1;
            playerStats.statModifier.baseResource++;
            Debug.Log("Used a stat point to increase resource!");
        }
        else
        {
            // Do nothing, because we have no stat points to spend.
        }
    }
}
