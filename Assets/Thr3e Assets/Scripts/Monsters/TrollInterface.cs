using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

public class TrollInterface : MonoBehaviour
{
    public string monsterName = "Troll";    // The name of the monster.
    public int xpValue = 100;               // The amount of XP killing this unit will yield;
    public const int maxHealth = 20;        // Maximum health this enemy can have.
    public int currentHealth;               // The current health this monster has.
    public int damageAmount = 5;            // How much damage this monster can deal.
    public float distanceToPlayer;          // Distance between monster and player.
    public float attackDistance = 1.0f;     // Distance check for ability to attack.
    public float attackSpeedTimer = 0.0f;   // The monster's attack speed.
    public bool canAttack;                  // Checks if the monster has waited long enough to attack again.
    public bool inRangeToAttack;            // Checks if monster is within distance to attack.
    public bool isAlive;                    // Checks if the monster is alive.
    private float time = 1.0f;              // Controls the timer in between attacks.
    public Vector3 position;                // The monster's current position.
    public PlayerInterface playerInterface; // The player's script.
    public Slider healthValue;              // Troll's health value.
    public GameObject healthBarUI;          // Troll's healthbar activation/deactivation.
    //NavMeshAgent agent;                   // DISABLED - We're destroying immediately, instead. Troll's NavMesh agent.
    Animator anim;                          // Troll's animator controller.

    void Start()
    {
        // When we spawn, set our alive state to true, and set our health values.
        // Update our health slider so the values are correct on time of spawn.
        // Set the animator variable for our monster.
        // Set our navmesh agent for the monster so they can move in the world.
        isAlive = true;
        currentHealth = maxHealth;
        healthValue.maxValue = maxHealth;
        healthValue.value = maxHealth;
        anim = GetComponent<Animator>();
        //agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        // Set our position so the player knows where to attack.
        distanceToPlayer = Vector3.Distance(this.transform.position, playerInterface.position);

        if (distanceToPlayer <= 2 && isAlive == true && playerInterface.isAlive == true)
        {
            inRangeToAttack = true;
            anim.SetBool("run", false);
            StartCoroutine(WaitToAttack());
        }
        else if (distanceToPlayer >= 2 && distanceToPlayer <= 30 && isAlive == true && playerInterface.isAlive == true)
        {
            anim.SetBool("run", true);
            inRangeToAttack = false;
            canAttack = false;
        }
        else
        {
            // Player is dead or out of range.
            anim.SetBool("attack03", false);
            anim.SetBool("run", false);
            anim.SetBool("idle01", true);
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public IEnumerator WaitToAttack()
    {
        if (attackSpeedTimer > 0)
        {
            canAttack = false;
            attackSpeedTimer -= time * Time.deltaTime;
            yield return null;
        }
        else
        {
            canAttack = true;
            Attack();
            yield return null;
        }
    }

    public void Attack()
    {
        if (playerInterface.isAlive)
        {
            // Start the attack through the attack animation.
            anim.SetBool("damage", false);
            anim.SetBool("attack03", true);
            canAttack = false;
        }
        else
        {
            // Our player must be dead or out of range. Stop the attack animation.
            anim.SetBool("attack03", false);
            canAttack = false;
        }
    }

    // Actual damage is applied on "attack03" in Animation tab as event.
    public void TriggerDamage()
    {
        playerInterface.healthValue.value -= damageAmount;
        playerInterface.currentHealth -= damageAmount;
        attackSpeedTimer = 2.0f;
    }

    public void TakeDamage(int damageAmount)
    {
        anim.SetBool("damage", true);
        healthValue.value -= damageAmount;
        currentHealth -= damageAmount;
    }

    public void Die()
    {
        anim.SetBool("damage", false);
        anim.SetBool("dead", true);
        anim.SetBool("attack03", false);
        // Change the behavior tree first before re-enabling this so you don't get errors!
        //agent.enabled = false;
        healthBarUI.SetActive(false);
        GiveXP();
        Destroy(this.gameObject);
        StartCoroutine(DropLoot());
    }

    public IEnumerator DropLoot()
    {
        Debug.Log("Troll dropped loot!");
        yield return null;
    }
    
    public void GiveXP()
    {
        playerInterface.XPBar.value += xpValue;
        Debug.Log("You earned " + xpValue + " XP from " + monsterName + "!");
    }
}