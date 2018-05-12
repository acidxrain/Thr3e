using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour, IDamageable, IAttackAgent
{
    public bool isAlive;
    private readonly bool Paused;
    public float maxHealth = 100;
    public float currentHealth;
    public Vector3 position;
    public Camera mainCamera;
    public GameObject currentTarget;
    public Slider healthValue;
    public Slider rageValue;
    Animator anim;
    public GameMenuActions gameMenuActions;
    public TrollInterface trollInterface;
    UnityEngine.AI.NavMeshAgent agent;
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
        // Set our position so the player knows where to attack.
        position = this.transform.position;

        // QUICK TEST FOR DAMAGE.
        if (Input.GetKeyDown(KeyCode.D) && isAlive == true)
        {
            TakeDamage();
        }

        // Check for an interaction command.
        if (Input.GetKey(KeyCode.Mouse0) && isAlive == true && !gameMenuActions.Paused)
        {

            RaycastHit hit;

            // Check if we're clicking on an interactable.
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 1000, this.interactableLayer))
            {
                agent.destination = hit.point;
            }

            else
            {
                Debug.Log("Can't move! Game is paused, player is dead, or clicked an object not interactable");
            }
        }
    }

    public void IsAlive(bool isAlive)
    {
        Debug.Log(isAlive);
    }

    public void TakeDamage(float damageAmount)
    {
        // Before we start taking damage, we should check to see if we're alive first.
        if (isAlive)
        {
            // If we're alive, get our current health value and apply the damage we took to it.
            currentHealth -= damageAmount;
        }
    }

    public void DealDamage(float damageAmount)
    {
        // Before we deal damage to the player, check to see if they're alive first.
        if (trollInterface.isAlive == true)
        {
            // If the player is alive, get the player's current health value 
            // from PlayerInterface and apply the damage amount.
            trollInterface.currentHealth -= damageAmount;
        }
        else
        {
            Debug.Log("We can't damage a dead monster!");
        }
    }

    // Returns the furthest distance that the agent is able to attack from.
    public void AttackDistance(float attackDistance)
    {
        attackDistance = 1.2f;
        Debug.Log("Current attack distance is: " + attackDistance + ".");
    }

    // Can the agent attack?
    public void CanAttack(bool canAttack)
    {
        if (currentTarget == null)
        {
            Debug.Log("We don't have a target!");
            if (trollInterface.isAlive == false)
            {
                Debug.Log("Our target is dead!");
            }
        }
        else
        {
            canAttack = true;
        }
    }

    // Returns the maximum angle that the agent can attack from.
    public void AttackAngle(float attackAngle)
    {
        attackAngle = 5.0f;
        Debug.Log("Setting attack angle!");
    }

    // Click to move and object interaction.
    public void Attack(Vector3 targetPosition)
    {

    }


    public void TakeDamage()
    {
        healthValue.value -= 5f;
        currentHealth = healthValue.value;
        Debug.Log("Taking 5 damage!");
        if (currentHealth <= 0f)
        {
            Die();
            Debug.Log("You are dead!");
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