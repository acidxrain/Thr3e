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
    public int pointsInStrength;
    public int pointsInAgility;
    public int pointsInHealth;
    public int pointsInResource;
    public Text uiStatPoints;        // For use later when hooking up the "Stat" menu. FINISH THIS!
    public Text uiSkillPoints;       // For use later when hooking up the "Stat" menu. FINISH THIS!
    public Text uiCurrentLevel;      // Display the current level of the player.
    public Text uiCurrentStrength;
    public Text uiCurrentAgility;
    public Text uiCurrentHealth;
    public Text uiCurrentResource;
    public Text uiPointsInStrength;
    public Text uiPointsInAgility;
    public Text uiPointsInHealth;
    public Text uiPointsInResource;
    public XPBar xpBar;              // The script of the XP bar.
    public StatModifier statModifier;// The stat modifier script to affect the stats.

    // Use this for initialization
    void Awake()
    {
        // As soon as we spawn in the world as a new character, we need to make sure we're set to the default values.
        currentStatPoints = 0;
        currentSkillPoints = 0;
        currentLevel = 1;
        pointsInStrength = 0;
        pointsInAgility = 0;
        pointsInHealth = 0;
        pointsInResource = 0;
        uiStatPoints = GameObject.Find("Points Left").GetComponentInChildren<Text>();
        uiSkillPoints = GetComponentInChildren<Text>();
        uiCurrentLevel = GameObject.Find("Level").GetComponentInChildren<Text>();
        uiCurrentStrength = GameObject.Find("Strength Amount").GetComponentInChildren<Text>();
        uiCurrentAgility = GameObject.Find("Agility Amount").GetComponentInChildren<Text>();
        uiCurrentHealth = GameObject.Find("Health Amount").GetComponentInChildren<Text>();
        uiCurrentResource = GameObject.Find("Resource Amount").GetComponentInChildren<Text>();
        uiPointsInStrength = GameObject.Find("Strength Point Count").GetComponentInChildren<Text>();
        uiPointsInAgility = GameObject.Find("Agility Point Count").GetComponentInChildren<Text>();
        uiPointsInHealth = GameObject.Find("Health Point Count").GetComponentInChildren<Text>();
        uiPointsInResource = GameObject.Find("Resource Point Count").GetComponentInChildren<Text>();
    }

    private void Update()
    {
        uiStatPoints.text = currentStatPoints.ToString();
        //uiSkillPoints.text = currentSkillPoints.ToString();
        uiCurrentLevel.text = currentLevel.ToString();
        uiCurrentStrength.text = statModifier.strength.ToString();
        uiCurrentAgility.text = statModifier.agility.ToString();
        uiCurrentHealth.text = statModifier.health.ToString();
        uiCurrentResource.text = statModifier.resource.ToString();
        uiPointsInStrength.text = pointsInStrength.ToString();
        uiPointsInAgility.text = pointsInAgility.ToString();
        uiPointsInHealth.text = pointsInHealth.ToString();
        uiPointsInResource.text = pointsInResource.ToString();
    }
}
