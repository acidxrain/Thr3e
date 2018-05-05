using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider Health;
    public Animator anim;
    public GameObject player;
    public GameObject deathScreen;
    public Vector3 respawnPosition;
    public int currentHealth;
    public bool isDead = false;
    public float maxHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPosition = new Vector3(0, 0, 0);
        maxHealth = Health.maxValue;
        deathScreen = GameObject.FindGameObjectWithTag("Dead");
        deathScreen.SetActive(false);
    }

    public void Update()
    {

    }

    public IEnumerator TakeDamage(int amount)
    {
        currentHealth = currentHealth - amount;
        Health.value = currentHealth;
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            currentHealth = 0;
            anim.SetBool("IsDead", true);
            isDead = true;
            deathScreen.SetActive(true);
            yield return null;
        }
    }

    public IEnumerator Respawn()
    {
        isDead = false;
        deathScreen.SetActive(false);
        anim.SetBool("IsDead", false);
        currentHealth = (int)maxHealth;
        player.transform.position = respawnPosition;
        Debug.Log("Respawning player with full health!");
        yield return null;
    }
}