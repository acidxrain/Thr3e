using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour, IDamageable
{
    public float currentHealth = 100;
    public bool isAlive;
    private float amount;

    // Implementation of IDamageable

    void IDamageable.Damage(float amout)
    {
        currentHealth -= amount;
    }

    //Implementation of IsAlive
    bool IDamageable.IsAlive()
    {
        throw new System.NotImplementedException();
    }
}