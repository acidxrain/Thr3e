using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    public bool isAlive;                                        // Checks if the player is alive.
    private readonly bool Paused;                               // Checks if the game is currently paused to stop input.
    public int maxHealth;                                       // The maximum health of the player.
    public int damageAmount;                                    // The player's damage amount.
    public int strength;                                        // The player's strength amount.
    public int agility;                                         // The player's agility amount.
    public int health;                                          // The player's health amount.
    public int resource;                                        // The player's resource amount.
    public int currentHealth;                                   // The player's current health amount.
    public int currentRage;                                     // The player's current resource amount.
    public int maxRage;                                         // The player's maximum resource amount.
    public float attackDelay;                                   // The player's attack speed delay.
    public Vector3 position;                                    // The playuer's current position in the world.
    public Camera mainCamera;                                   // The camera that follows the player.
    public Slider healthValue;                                  // The player's current health shown on the UI slider.
    public Slider rageValue;                                    // The player's current resource shown on the UI slider.
    public Slider XPBar;                                        // The player's current XP shown on the UI slider.
    public GameMenuActions gameMenuActions;                     // The script for the menu that shows when pressing "Escape" key.
    public TrollInterface trollInterface;                       // The Troll monter's script to get variables.
    public StatModifier statModifier;                           // The script used to pull stat variables from level-up's.
    Animator anim;                                              // The animator that drives the player's animations.
    NavMeshAgent agent;                                         // The agent that drives the player's movement in the world.
    [SerializeField] private LayerMask interactableLayer;       // This layer contains anything the player can actually interact with by clicking.

    void Awake()
    {
        mainCamera = Camera.main;                    // Set our camera variable name to mainCamera.
        maxHealth = statModifier.health;             // Set our maximum health to whatever our max health value is in StatModifier.
        currentHealth = maxHealth;                   // Set our current health to our maximum health value when we spawn.
        healthValue.maxValue = statModifier.health;  // Set our player's health slider maximum value to our max health value in StatModifier.
        healthValue.value = maxHealth;               // Set our player's health slider value to our max health value in StatModifier so we don't die.
        damageAmount = statModifier.strength;        // Set our player's damage to our strength value after StatModifier calculations.
        rageValue.maxValue = statModifier.resource;  // Set our player's resource slider maximum to our max resource value in StatModifier.
    }

    void Start()
    {
        // When we spawn, set our alive state to true, cache the navmesh agent, and set our health values.
        isAlive = true;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        Vector3 position = transform.position;
    }

    void Update()
    {
        // Set our position so the monster knows where to attack.
        position = this.transform.position;
        attackDelay = Math.Max(0, attackDelay - Time.deltaTime);
        damageAmount = statModifier.strength;
        healthValue.maxValue = statModifier.health;
        rageValue.maxValue = statModifier.resource;

        // Check for an interaction command.
        if (Input.GetKey(KeyCode.Mouse0) && isAlive == true && !gameMenuActions.Paused)
        {

            RaycastHit hit;

            // Check what layer we're interacting with and perform the correct action.
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 1000, this.interactableLayer))
            {
                int objectClicked = hit.collider.gameObject.layer;
                GameObject go = hit.collider.gameObject; //the object that was hit by the ray


                // If we click a monster, go to it and attack.
                if (objectClicked == 11)
                {
                    agent.destination = go.transform.position;
                    agent.stoppingDistance = 1.2f;
                    transform.LookAt(go.transform.position);

                    if (agent.remainingDistance >= agent.stoppingDistance)
                    {
                        anim.SetBool("moving", true);
                    }
                    else if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        anim.SetBool("moving", false);

                        if (attackDelay == 0) // Add a check for the attack timer here to see if we can attack yet.
                        {          
                            TrollInterface ti = go.GetComponent<TrollInterface>();

                            if (ti != null)
                            {
                                Attack(ti);
                            }
                        }
                        else
                        {
                            // Can't attack yet! Set the attack animation to false;
                            anim.SetBool("isAttacking", false);
                        }
                    }

                }
                // If we click the ground, move on the navmesh to our destination.
                else if (objectClicked == 9)
                {
                    agent.stoppingDistance = 0.0f;
                    agent.destination = hit.point;
                }
                // If we click a barrell, go to it and attack.
                else if (objectClicked == 12)
                {
                    agent.stoppingDistance = 1.2f;
                    agent.destination = go.transform.position;
                    Debug.Log("Interactables not yet implemented!");
                }
            }
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Attack(TrollInterface ti) //Passing the troll we're attacking
    {
        // Before we deal damage to the monster, check to see if they're alive first.
        if (ti.isAlive == true)
        {
            anim.SetBool("isAttacking", true);
            attackDelay += 1;
            StartCoroutine(DealDamage(ti));
        }
    }

    public IEnumerator DealDamage(TrollInterface ti)
    {
        yield return new WaitForSeconds(0.3f);
        ti.TakeDamage(damageAmount);
        if (rageValue.value != rageValue.maxValue)
        {
            rageValue.value += 5;
        }
        yield return null;
    }

    // When the player dies.
    public void Die()
    {
        isAlive = false;
        anim.SetBool("isDead", true);
        Debug.Log("You are dead!");
    }

    public void Respawn()
    {
        Debug.Log("Respawning!");
        anim.SetBool("isDead", false);
        anim.SetBool("isIdle", true);
        currentHealth = maxHealth;
        healthValue.value = maxHealth;
        isAlive = true;
        gameMenuActions.DisableDeadText();
    }
}