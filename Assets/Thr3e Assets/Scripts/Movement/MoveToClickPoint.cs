// MoveToClickPoint.cs
using System.Collections;
using UnityEngine;

public class MoveToClickPoint : MonoBehaviour
{
    public Animator anim;
    public bool playerAttacking = false;
    public bool playerWalking = false;
    public bool playerIdle = false;
    UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private LayerMask _groundLayer;
    public Camera mainCamera;
    public GameMenuActions gameMenuActions;
    private bool Paused;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (agent.velocity.sqrMagnitude < 0.5f )
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", false);
            playerWalking = false;
            playerIdle = true;
        }

        if (Input.GetKey(KeyCode.Mouse0) && gameMenuActions.Paused == false)
        {
            RaycastHit hit;

            //Ignore walls with the raycast through bitshift layermask and allow walking on ground when clicked.
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 1000, this._groundLayer))
            {
                agent.destination = hit.point;
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);
                playerWalking = true;
                playerIdle = false;
            }
        }
    }
}
