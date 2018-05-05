using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnButtonFunction : MonoBehaviour {

    public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnButtonPressed()
    {
        StartCoroutine(playerHealth.Respawn());
    }
}
