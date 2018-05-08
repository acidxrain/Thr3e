using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

	public float currentHealth = 100;
	public float maxHealth = 100;

	public float startingHealth = 100;
	public Image healthBar;
	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		healthBar.fillAmount = currentHealth / startingHealth;

		if (currentHealth <= 0)
		{
			Die();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Die()
	{
		Debug.Log("Enemy has died!");
	}
}
