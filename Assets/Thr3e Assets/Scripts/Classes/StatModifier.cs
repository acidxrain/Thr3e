using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier : MonoBehaviour {

    public PlayerStats playerStats;
    public PlayerInterface playerInterface;
    public int baseStrength = 1;
    public int strength;
    public int baseAgility = 1;
    public int agility;
    public int baseHealth = 20;
    public int health;
    public int baseResource = 1;
    public int resource;
    public int baseDamage = 1;
    public int damage;
    public int strengthModifierValue = 5;
    public int agilityModifierValue = 5;
    public int healthModifierValue = 5;
    public int resourceModifierValue = 5;

    // Use this for initialization
    void Awake ()
    {
        strength = baseStrength * strengthModifierValue;
        agility = baseAgility * agilityModifierValue;
        health = baseHealth * healthModifierValue;
        resource = baseResource * resourceModifierValue;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
