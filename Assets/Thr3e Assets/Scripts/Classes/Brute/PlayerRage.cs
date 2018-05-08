using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRage : MonoBehaviour
{

    public Slider Rage;
    //Set the default amount of rage the Brute gets.
    public int startingRage = 50;
    //Store current rage in var when spending.
    public float currentRage;
    //The amount of rage the Brute gets after attacking.
    public int amount;

    void Start()
    {
        Rage.value = currentRage;
    }

    public IEnumerator IncreaseRage(int amount)
    {
        currentRage = currentRage + amount;
        Rage.value = currentRage;
        yield return null;
    }

    public IEnumerator DecreaseRage(int amount)
    {
        currentRage = currentRage - amount;
        Rage.value = currentRage;
        yield return null;
    }
}
