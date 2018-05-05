using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickToMove : MonoBehaviour
{
    public Animator anim;
    private GameObject monster;
    public GameObject PlayerRay;
    public GameObject enemySlider;
    public EnemyAttack mob;
    public PlayerRage playerRage;
    public RaycastHit destination;
    public RaycastHit hit;
    private Vector3 selectedDestination;
    private Transform myTransform;
    private Vector3 destinationPosition;
    private Vector3 focusedDestination;
    public PlayerHealth playerHealth;
    public GameMenuActions gameMenuActions;
    public bool Walking = false;
    public bool playerAttacking = false;
    public bool movingToAttack;
    public float rotstep = 3.0f;
    public float distanceToMonster;
    UnityEngine.AI.NavMeshAgent agent;

    //Character Stats
    public int damage = 20;
    public float attackSpeed = 1.0f;
    public float autoAttackDistance = 1.5f;
    private float destinationDistance;
    public float moveSpeed = 3.0f;
    public float amount = 5.0f;
    //Layer Mask
    public LayerMask layerMask;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = transform;
        destinationPosition = myTransform.position;
        enemySlider = GameObject.FindGameObjectWithTag("Enemy Health");
        enemySlider.SetActive(false);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (gameObject.GetComponent<PlayerHealth>().isDead == false)
            {
                if (GetComponent<GameMenuActions>().Paused == false)
                {
                    Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray1, out hit, 1000, layerMask.value))
                    {
                        if (hit.transform.gameObject.tag == "Enemy" && hit.transform.gameObject.tag != null)
                        {
                            enemySlider.SetActive(true);
                            monster = hit.transform.gameObject;
                            mob = monster.GetComponent<EnemyAttack>();
                            movingToAttack = true;
                            Debug.Log("Ray hit monster, moving to target!");
                            distanceToMonster = Vector3.Distance(transform.position, monster.transform.position);
                        }
                        else
                        {
                            movingToAttack = false;
                            focusedDestination = hit.point;
                            Debug.Log("Ray hit walkable surface.");
                        }
                    }

                    Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 0.2f);

                    if (hit.transform == null)
                    {
                        return;
                    }

                    if (hit.transform.gameObject.tag == "Ground")
                    {
                        selectedDestination = focusedDestination;
                    }

                    if (Walking == false)
                    {
                        StartCoroutine(ClickMove());
                    }
                }
            }
        }
    }

    public IEnumerator ClickMove()
    {
        Walking = true;
        while (Walking)
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsWalking", true);

            if (movingToAttack && mob.isDead == false)
            {
                Vector3 targetDir = monster.transform.position - transform.position;
                if (transform.forward != targetDir)
                {
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotstep, 0.0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                    //New NavMesh Experimental
                    agent.destination = newDir;
                }

                transform.position = Vector3.MoveTowards(transform.position, monster.transform.position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, monster.transform.position) <= autoAttackDistance)
                {
                    anim.SetBool("IsWalking", false);

                    if (playerAttacking == false)
                    {
                        selectedDestination = monster.transform.position;
                        //New NavMesh Experimental
                        agent.destination = selectedDestination;
                        Walking = false;
                        StartCoroutine(PlayerAttack());
                    }
                }
            }
            else
            {
                Vector3 targetDir = selectedDestination - transform.position;
                if (transform.forward != targetDir)
                {
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotstep, 0.0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }

                transform.position = Vector3.MoveTowards(transform.position, selectedDestination, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, selectedDestination) == 0)
                {
                    anim.SetBool("IsWalking", false);
                    selectedDestination = transform.position;
                    Walking = false;
                }
            }
        yield return null;
        }
        yield return null;
    }

    //Player attacking script
    public IEnumerator PlayerAttack()
    {
        if (playerAttacking == false)
        {
            playerAttacking = true;
            anim.SetBool("IsAttacking", true);
            enemySlider.GetComponent<Slider>().value = monster.GetComponent<EnemyAttack>().mobHealth;
            StartCoroutine(monster.GetComponent<EnemyAttack>().Hurt(damage));

            //Give the player 5 resource for a successful auto-attack.
            //Will later need to get the player's class and generate only the correct resource.
            StartCoroutine(playerRage.IncreaseRage(10));
            enemySlider.GetComponent<Slider>().value = monster.GetComponent<EnemyAttack>().mobHealth;
            yield return new WaitForSeconds(attackSpeed);
            anim.SetBool("IsAttacking", false);
            playerAttacking = false;

            yield return null;
        }
    }
}
