using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjects : MonoBehaviour
{

    public Vector3 mousePos;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 5;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //Debug.DrawLine(gameObject.transform.position, mousePos, Color.red, 1);
        //Debug.Log(mousePos);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit;
        hit = Physics.SphereCastAll (Camera.main.transform.position, 2.5f, player.transform.position, 50f);
        //Debug.Log(hit);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.gameObject.tag == "Wall")
            {
                //Debug.DrawRay(Camera.main.transform.position, hit[i].collider.transform.position, Color.green, 1f);
                //Debug.Log(hit[i].transform.gameObject.tag);
                hit[i].collider.gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

    }
}
