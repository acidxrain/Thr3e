using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public Vector3 monsterPos;
    public PlayerHealth playerHealth;
    public float playerXP;
    public Animator anim;
    public float speed = 6f;
    public float moveSpeed;
    public float distance;
    public float attackDistance = 1.5f;
    public float detectionDistance = 5f;
    public bool inSight;
    public bool attackLimiter = false;
    //New NavMesh Experimental
    UnityEngine.AI.NavMeshAgent agent;

    //Enemy statistics
    //How much damage the mob does.
    public int damage = 1;
    //How much health the mob has. Use this for tweaking.
    public float mobHealth = 50;
    //How much health the mob spawns with.
    public float maxHealth = 50;
    //If the mob is dead or not.
    public bool isDead = false;

    // Use this for initialization
    void Start()
    {
        inSight = false;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //playerXP = player.GetComponent<PlayerExperience>().Experience.value;
        anim.SetBool("IsDead", false);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //This is the coroutine for PlayerExperience experience gain.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(player.GetComponent<PlayerExperience>().IncreaseXP(1));
        }
        monsterPos = monster.transform.position;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= detectionDistance && attackLimiter == false && playerHealth.isDead == false)
        {
            StartCoroutine(MoveToPlayer());
        }
        //Attack the player if we get close enough.
        if (distance <= attackDistance && attackLimiter == false)
        {
            anim.GetBool("IsAttacking");
            anim.SetBool("IsWalking", false);
            attackLimiter = true;
            StartCoroutine(AttackPlayer());

        }
    }

    public IEnumerator MoveToPlayer()
    {
        if (playerHealth.isDead == false)
        {
            inSight = true;
            moveSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);
            anim.SetBool("IsWalking", true);
            transform.LookAt(player.transform);
            //New NavMesh Experimental
            agent.destination = transform.position;
            yield return null;
        }
        else
        {
            Debug.Log("CRITICAL ERROR: 1");
        }
    }

    public IEnumerator AttackPlayer()
    {
        if (playerHealth.isDead == false)
        {
            anim.GetBool("IsWalking");
            anim.SetBool("IsAttacking", true);
            StartCoroutine(playerHealth.TakeDamage(damage));
            yield return new WaitForSeconds(2.767f);
            attackLimiter = false;
            yield return null;
        }
        else if (playerHealth.isDead == true)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", false);
            yield return null;
        }
    }

    public IEnumerator Hurt(int amount)
    {
        mobHealth -= amount;

        if (mobHealth <= 0)
        {
            mobHealth = 0;
            anim.SetBool("IsDead", true);
            StartCoroutine(player.GetComponent<PlayerExperience>().IncreaseXP(20));
            yield return new WaitForSeconds(4.0f);
            //Causes healthbar to show when they're dead. Enabling this fixes healthbar, but resets XP value slider.
            //GameObject.FindGameObjectWithTag("Enemy Health").SetActive(false);
            Destroy(this.gameObject);
            Debug.Log(player.GetComponent<PlayerExperience>().currentXP);
            yield return null;
        }
    }
}
