using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int currentStatPoints;    // The current amount of Stat points for the player to spend.
    public int currentSkillPoints;   // The current amount of Skill points for the player to spend.
    public int strength;             // The current amount of Strength the player has.
    public int agility;              // The current amount of Agility the player has.
    public int health;               // The current amount of Health the player has.
    public int resource;             // The current amount of Resource (Mana, Rage, etc) the player has.
    public Text statPoints;          // For use later when hooking up the "Stat" menu. FINISH THIS!
    public Text skillPoints;         // For use later when hooking up the "Stat" menu. FINISH THIS!

    // Use this for initialization
    void Start()
    {
        currentStatPoints = 0;
        currentSkillPoints = 0;
        strength = 0;
        agility = 0;
        health = 0;
        resource = 0;
    }

    public void UseSkillPoint()
    {
        Debug.Log("Used a skill point!");
        if (currentSkillPoints >= 1)
        {
            currentSkillPoints--;
        }
        else
        {
            Debug.Log("You don't have any skill points available!");
        }
    }

    public void IncreaseStrength()
    {
        if (currentSkillPoints >= 1)
        {
            currentSkillPoints--;
            strength++;
        }
        else
        {
            Debug.Log("You don't have any stat points to use!");
        }
    }

    public void IncreaseAgility()
    {
        if (currentSkillPoints >= 1)
        {
            currentSkillPoints--;
            agility++;
        }
        else
        {
            Debug.Log("You don't have any stat points to use!");
        }
    }

    public void IncreaseHealth()
    {
        if (currentSkillPoints >= 1)
        {
            currentSkillPoints--;
            health++;
        }
        else
        {
            Debug.Log("You don't have any stat points to use!");
        }
    }

    public void IncreaseResource()
    {
        if (currentSkillPoints >= 1)
        {
            currentSkillPoints--;
            resource++;
        }
        else
        {
            Debug.Log("You don't have any stat points to use!");
        }
    }
}
