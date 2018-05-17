using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPBar : MonoBehaviour {

    public float xpModifier = 4.0f;         // Each time the player levels, how much more do they need to earn than the previous level?
    public int currentLevel;                // Displays the player's current level.
    public int maxLevel = 99;               // Sets the maximum level the player can achieve.
    public float xpLossAmount;              // How much XP is lost when the player dies.
    public float levelUpValue;              // The amount of XP the player needs to level up.
    public PlayerInterface playerInterface; // The player's script.
    public PlayerStats playerStats;         // The script used to award stat and skill points upon leveling.
    public GameObject levelUpText;          // The text to show when the player levels up.
    public AudioClip levelUpClip;           // The sound effect that plays when the player levels up.

    // Use this for initialization
    void Start ()
    {
        currentLevel = 1;
        levelUpValue = playerInterface.XPBar.maxValue;
        levelUpText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (playerInterface.XPBar.value == levelUpValue)
        {
            LevelUp();
            StartCoroutine(ShowLevelUpText());
        }

        if (playerInterface.isAlive == false)
        {
            if (currentLevel < 99 && playerInterface.XPBar.value >= 2)
            {
                // If the player dies, remove some of their XP.
                xpLossAmount = playerInterface.XPBar.value / 1.35f;
                playerInterface.XPBar.value -= xpLossAmount;
            }
            else
            {
                // You got lucky!
                Debug.Log("Can't remove XP from a player who has no XP to lose or is level 99!");
            }
        }
	}

    public void LevelUp()
    {
        if (currentLevel == maxLevel)
        {
            // Disable the entire XP bar, since we're max level.
        }
        else
        {
            Debug.Log("Level up!");
            playerInterface.XPBar.value = 0;
            currentLevel++;
            GetComponent<AudioSource>().Play();
            playerInterface.XPBar.maxValue = playerInterface.XPBar.maxValue * xpModifier;
            levelUpValue = playerInterface.XPBar.maxValue;
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
