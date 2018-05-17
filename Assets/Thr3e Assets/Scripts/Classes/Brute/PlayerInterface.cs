using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    public bool isAlive;
    private readonly bool Paused;
    public float maxHealth = 100;
    public float damageAmount = 5;
    public float currentHealth;
    public float attackDelay;
    public Vector3 position;
    public Camera mainCamera;
    public GameObject currentTarget;
    public Slider healthValue;
    public Slider rageValue;
    public Slider XPBar;
    Animator anim;
    public GameMenuActions gameMenuActions;
    public TrollInterface trollInterface;
    NavMeshAgent agent;
    [SerializeField] private LayerMask interactableLayer;

    void Start()
    {
        // When we spawn, set our alive state to true, cache the navmesh agent, and set our health values.
        isAlive = true;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        Vector3 position = transform.position;
    }

    void Awake()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        // Set our position so the monster knows where to attack.
        position = this.transform.position;

        attackDelay = Math.Max(0, attackDelay - Time.deltaTime);

        // Check for an interaction command.
        if (Input.GetKey(KeyCode.Mouse0) && isAlive == true && !gameMenuActions.Paused)
        {

            RaycastHit hit;

            // Check what layer we're interacting with and perform the correct action.
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 1000, this.interactableLayer))
            {
                int objectClicked = hit.collider.gameObject.layer;
                GameObject go = hit.collider.gameObject;

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
                            Attack();
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

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Attack()
    {
        // Before we deal damage to the player, check to see if they're alive first.
        if (trollInterface.isAlive == true)
        {
            anim.SetBool("isAttacking", true);
            attackDelay += 1;
            this.trollInterface.TakeDamage(damageAmount);
        }
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