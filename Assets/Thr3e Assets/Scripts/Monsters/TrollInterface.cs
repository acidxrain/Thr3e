using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrollInterface : MonoBehaviour, IDamageable, IIsAlive, IAttackAgent
{
    public int maxHealth = 100;
    public float currentHealth;
    public float damageAmount = 5;
    public float attackAngle;
    public float attackDistance;
    public bool isAlive;
    public GameObject currentTarget;
    public Vector3 currentTargetPosition;
    public Vector3 position;
    public PlayerInterface playerInterface;

    void Start()
    {
        //When we spawn, set our alive state to true.
        isAlive = true;
    }

    void Update()
    {
        //Set our position so the player knows where to attack.
        position = this.transform.position;
    }

    public void IsAlive(bool isAlive)
    {
        Debug.Log(isAlive);
    }

    public void TakeDamage(float damageAmount)
    {
        //Before we start taking damage, we should check to see if we're alive first.
        if (isAlive == true)
        {
            //If we're alive, get our current health value and apply the damage we took to it.
            currentHealth -= damageAmount;
        }
        //If we're not alive, set our state to dead.
        else if (currentHealth <= 0)
        {
            //If we're dead, let the console know. Remove this later to get rid of console debug spam.
            isAlive = false;
            Debug.Log("We are dead. We can't take any more damage!");
        }
        else
        {
            Debug.Log("Error! Critical failure in TakeDamage function!");
        }
    }

    public void DealDamage(float damageAmount)
    {
        //Before we deal damage to the player, check to see if they're alive first.
        if (playerInterface.isAlive == true)
        {
            //If the player is alive, get the player's current health value from PlayerInterface and apply the damage amount.
            playerInterface.currentHealth -= damageAmount;
        }
        else
        {
            Debug.Log("We can't damage a dead player!");
        }
    }

    //Returns the furthest distance that the agent is able to attack from.
    public void AttackDistance(float attackDistance)
    {
        attackDistance = 1.2f;
        Debug.Log("Current attack distance is: " + attackDistance + ".");
    }

    //Can the agent attack?
    public void CanAttack(bool canAttack)
    {
        if (currentTarget == null)
        {
            Debug.Log("We don't have a target!");
            if (playerInterface.isAlive == false)
            {
                Debug.Log("Our target is dead!");
            }
        }
        else
        {
            canAttack = true;
        }
    }

    //Returns the maximum angle that the agent can attack from.
    public void AttackAngle(float attackAngle)
    {
        attackAngle = 5.0f;
        Debug.Log("Setting attack angle!");
    }

    //Does the actual attack.
    public void Attack(Vector3 targetPosition)
    {
        currentTargetPosition = playerInterface.position;
        Debug.Log("Attacking target!");
    }

}
