using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider Health;
    public int currentHealth;

    public IEnumerator TakeDamage(int amount)
    {
        currentHealth = currentHealth - amount;
        Health.value = currentHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            yield return null;
        }
    }

    public void Update()
    {
    }
}