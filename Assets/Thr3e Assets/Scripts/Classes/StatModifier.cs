using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier : MonoBehaviour {

    public PlayerStats playerStats;
    public PlayerInterface playerInterface;

    // The names of the four stats.
    public int strength;
    public int agility;
    public int health;
    public int resource;

    // Each player gets the defined amount in each stat listed below on spawn.
    private int baseStrength = 1;
    private int baseAgility = 1;
    private int baseHealth = 100;
    private int baseResource = 50;

    // Modifiers to specify how much one point in each stat gives.
    private const int strengthModifierValue = 1;
    private const int agilityModifierValue = 1;
    private const int healthModifierValue = 1;
    private const int resourceModifierValue = 1;

    // The current value of each stat after the modifier and base stats are multiplied.
    public int currentBaseStrength;
    public int currentBaseAgility;
    public int currentBaseHealth;
    public int currentBaseResource;

    // Use this for initialization
    void Awake ()
    {
        strength = baseStrength * strengthModifierValue;
        agility = baseAgility * agilityModifierValue;
        health = baseHealth * healthModifierValue;
        resource = baseResource * resourceModifierValue;
	}

    void Update()
    {
        strength = baseStrength * strengthModifierValue;
        agility = baseAgility * agilityModifierValue;
        health = baseHealth * healthModifierValue;
        resource = baseResource * resourceModifierValue;
    }

    public void IncreaseBaseStrength()
    {
        baseStrength++;
        currentBaseStrength = baseStrength;
    }

    public void IncreaseBaseAgility()
    {
        baseAgility++;
        currentBaseAgility = baseAgility;
    }

    public void IncreaseBaseHealth()
    {
        baseHealth++;
        currentBaseHealth = baseHealth;
    }

    public void IncreaseBaseResource()
    {
        baseResource++;
        currentBaseResource = baseResource;
    }
}
