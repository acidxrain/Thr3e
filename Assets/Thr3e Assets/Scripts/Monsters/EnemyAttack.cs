using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public Vector3 monsterPos;
    public PlayerHealth playerHealth;
    public Animator anim;
    public float speed = 6f;
    public float moveSpeed;
    public float distance;
    public float attackDistance = 1.0f;
    public float detectionDistance = 5f;
    public bool inSight;
    public bool attackLimiter = false;
    public bool isDead = false;
    
    //Enemy statistics
    //How much damage the mob does.
    public int damage = 1;
    //How much health the mob has. Use this for tweaking.
    public float mobHealth = 50;
    //How much health the mob spawns with. Do not tweak unless necessary.
    public float maxHealth = 50;

    // Use this for initialization
    void Start()
    {
        inSight = false;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim.SetBool("IsDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        monsterPos = monster.transform.position;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= detectionDistance && attackLimiter == false && isDead == false)
        {
            StartCoroutine(MoveToPlayer());
        }
    }

    public IEnumerator MoveToPlayer()
    {
        inSight = true;
        moveSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);
        anim.SetBool("IsWalking", true);
        transform.LookAt(player.transform);
        yield return null;
        //Attack the player if we get close enough.
        if (distance <= attackDistance && attackLimiter == false)
            {
                anim.GetBool("IsAttacking");
                anim.SetBool("IsWalking", false);
                StartCoroutine(AttackPlayer());
                attackLimiter = true;
            }
    }

    public IEnumerator AttackPlayer()
    {
        anim.GetBool("IsWalking");
        anim.SetBool("IsAttacking", true);
        StartCoroutine(playerHealth.TakeDamage(damage));
        yield return new WaitForSeconds(2.767f);
        anim.SetBool("IsAttacking", false);
        attackLimiter = false;
        yield return null;
    }

    public IEnumerator Hurt(int amount)
    {
        mobHealth -= amount;
        
        

        if (mobHealth <= 0)
        {
            mobHealth = 0;
            anim.SetBool("IsDead", true);
            isDead = true;
            yield return new WaitForSeconds(4.0f);
            GameObject.FindGameObjectWithTag("Enemy Health").SetActive(false);
            Destroy(this.gameObject);
            yield return null;
        }
    }
}
