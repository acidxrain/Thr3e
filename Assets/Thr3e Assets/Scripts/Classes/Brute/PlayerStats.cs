using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int currentLevel;         // The current level of the player.
    public int maxLevel = 99;        // Sets the maximum level the player can achieve.
    public int xpModifier = 4;       // Each time the player levels, how much more do they need to earn than the previous level?
    public int currentStatPoints;    // The current amount of Stat points for the player to spend.
    public int currentSkillPoints;   // The current amount of Skill points for the player to spend.
    public int currentStrength;      // The current amount of Strength the player has.
    public int currentAgility;       // The current amount of Agility the player has.
    public int currentHealth;        // The current amount of Health the player has.
    public int currentResource;      // The current amount of Resource (Mana, Rage, etc) the player has.
    public Text uiStatPoints;        // For use later when hooking up the "Stat" menu. FINISH THIS!
    public Text uiSkillPoints;       // For use later when hooking up the "Stat" menu. FINISH THIS!
    public Text uiCurrentLevel;      // Display the current level of the player.
    public XPBar xpBar;              // The script of the XP bar.
    public StatModifier statModifier;// The stat modifier script to affect the stats.

    // Use this for initialization
    void Awake()
    {
        // As soon as we spawn in the world as a new character, we need to make sure we're set to the default values.
        currentStatPoints = 0;
        currentSkillPoints = 0;
        currentLevel = 1;
        currentStrength =  statModifier.strength;
        currentAgility = statModifier.agility;
        currentHealth = statModifier.health;
        currentResource = statModifier.resource;
        uiStatPoints = GameObject.Find("Points Left").GetComponentInChildren<Text>();
        uiSkillPoints = GetComponentInChildren<Text>();
        uiCurrentLevel = GameObject.Find("Level").GetComponentInChildren<Text>();
    }

    private void Update()
    {
        uiStatPoints.text = currentStatPoints.ToString();
        //uiSkillPoints.text = currentSkillPoints.ToString();
        uiCurrentLevel.text = currentLevel.ToString();
    }
}
