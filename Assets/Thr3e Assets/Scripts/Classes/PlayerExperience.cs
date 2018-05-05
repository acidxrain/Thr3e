using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour {

    public Slider xpSlider;
    public GameObject player;
    public float startingXP = 0;      //Set the default amount of xp the Brute gets.
    public float experienceCap = 100;//Set the max value of the level so the modifier can change it with each levelup.
    public float currentXP;           //Store current XP in var when spending.
    public int startingLevel = 1;     //Set the starting level of the player.
    public int currentLevel = 1;      //Store the player's current level in a variable.
    public int maxLevel = 99;         //Set the max level player can achieve.
    public int currentStatPoints = 0; //Store the amount of stat points the player has into a variable, but start them with 0.
    public float amount;              //The amount of XP the player gets after killing an enemy.
    private bool playerLeveled;       //Use this bool to trigger the award of stat points to the player each time they level.
    public float carryOverXP;         //If the player has XP leftover from leveling up, append the leftover XP to the next leve's progress.
    public float xpModifier = 2f;     //Set the XP modifier for each level.

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        xpSlider = player.transform.Find("Game UI/Skillbar Canvas/XP").GetComponent<Slider>();
        xpSlider.value = currentXP;
        experienceCap = xpSlider.maxValue;
        currentLevel = startingLevel;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public IEnumerator IncreaseXP(int amount)
    {
        currentXP = currentXP + amount;
        xpSlider.value = currentXP;
        if ((currentXP + amount) >= experienceCap)
        {
            carryOverXP = currentXP - experienceCap;
            StartCoroutine(LevelUp());
        }
        yield return null;
    }

    //This is for testing. Trigger for this CoRoutine resides in EnemyAttack.cs!
    public IEnumerator IncreaseXP1(int amount)
    {
        currentXP = currentXP + amount;
        xpSlider.value = currentXP;
        yield return null;
    }
    //This is for testing. Trigger for this CoRoutine resides in EnemyAttack.cs!

    public IEnumerator LevelUp()
    {
        if (xpSlider.value >= experienceCap)
        {
            //Reset XP to 0.
            xpSlider.value = 0;
            //Carry over extra XP from last level.
            xpSlider.value += carryOverXP;
            //Set slider value to next level's value.
            experienceCap = (experienceCap * xpModifier);
            //Gain a level.
            StartCoroutine(LevelIncrease());
            //Gain 5 stat points.
            StartCoroutine(StatPointIncrease());
            yield return null;
        }
    }

    public IEnumerator LevelIncrease()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            playerLeveled = true;
        }
        yield return null;
    }

    public IEnumerator StatPointIncrease()
    {
        if (playerLeveled == true)
        {
            currentStatPoints = currentStatPoints + 5;
            playerLeveled = false;
        }
        yield return null;
    }
}
