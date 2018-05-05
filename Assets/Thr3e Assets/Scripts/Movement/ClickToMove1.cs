using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove1 : MonoBehaviour {

    private Vector3 position;
    public float speed;
    public CharacterController controller;
    UnityEngine.AI.NavMeshAgent agent;


    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            locatePosition();
        }	
	}

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log(position);
        }
    }

    void moveToPosition()
    {
        if(Vector3.Distance(transform.position, position) > 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward);
            agent.destination = position;
        }
    }
}
