using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPBar : MonoBehaviour {

    public int currentLevel;                // Displays the player's current level.
    public int xpLossAmount;                // How much XP is lost when the player dies.
    public PlayerInterface playerInterface; // The player's script.
    public PlayerStats playerStats;         // The script used to grab the player's current level.
    public LevelUp levelUp;                 // The script used to level the player up and award stat points and skill points.
	
	// Update is called once per frame
	void Update ()
    {
	    if (playerInterface.XPBar.value == levelUp.levelUpValue)
        {
            levelUp.IncreaseLevel();
            StartCoroutine(levelUp.ShowLevelUpText());
        }

        if (playerInterface.isAlive == false)
        {
            if (currentLevel < 99 && playerInterface.XPBar.value >= 2)
            {
                // If the player dies, remove some of their XP.
                xpLossAmount = (Mathf.RoundToInt (playerInterface.XPBar.value / 2));
                playerInterface.XPBar.value -= xpLossAmount;
            }
            else
            {
                // You got lucky!
                Debug.Log("Can't remove XP from a player who has no XP to lose or is level 99!");
            }
        }
	}
}
