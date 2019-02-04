using System.Collections;
using UnityEngine.UI;
using UnityEngine;

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

}