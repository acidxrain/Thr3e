using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{

    public PlayerStats playerStats;         // The script that holds the stats of the player so we can affect our player's stats here.
    public PlayerInterface playerInterface; // The player script.
    public XPBar xpBar;                     // The XP bar script.
    public GameObject levelUpText;          // The text to show when the player levels up.
    public AudioClip levelUpClip;           // The sound effect that plays when the player levels up.
    public int levelUpValue;                // The amount of XP the player needs to level up.

    private void Start()
    {
        levelUpValue = (Mathf.RoundToInt(playerInterface.XPBar.maxValue)); // Set our initial level up value to an int, instead of float.
        levelUpText.SetActive(false);                                      // Hide the level-up text at the start.
    }

    public void IncreaseLevel()
    {
        if (playerStats.currentLevel == playerStats.maxLevel)
        {
            // Disable the entire XP bar, since we're max level.
        }
        else
        {
            Debug.Log("Level up!");
            playerInterface.XPBar.value = 0;
            playerStats.currentLevel += 1;
            GetComponent<AudioSource>().Play();
            playerInterface.XPBar.maxValue = playerInterface.XPBar.maxValue * playerStats.xpModifier;
            levelUpValue = (Mathf.RoundToInt(playerInterface.XPBar.maxValue));
            AwardStatPoints();
            AwardSkillPoint();
        }
    }

    public void AwardStatPoints()
    {
        // Award 5 stat points to the player.
        Debug.Log("You've gained 5 stat points!");
        playerStats.currentStatPoints += 5;
    }

    public void AwardSkillPoint()
    {
        // Award 1 skill point to the player.
        Debug.Log("You've earned a new skill point!");
        playerStats.currentSkillPoints += 1;
    }

    public IEnumerator ShowLevelUpText()
    {
        levelUpText.SetActive(true);
        yield return new WaitForSeconds(5);
        levelUpText.SetActive(false);
        yield return null;
    }
}
