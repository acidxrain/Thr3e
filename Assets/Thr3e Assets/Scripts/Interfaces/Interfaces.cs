using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Anything that can be damaged will use this interface.
public interface IDamageable
{
    //Take damage by the specified amount.
    void TakeDamage(float damageAmount);

    void DealDamage(float damageAmount);
}

//Anything that can be destroyed will use this interface.
public interface IIsAlive
{
    //Is the object currently alive?
    void IsAlive(bool isAlive);
}

//Anything that can heal will use this interface.
public interface IHealable
{
    //Specify how much to heal.
    void Healable(int healAmount);
}

//Anything that can attack will use this interface.
public interface IAttackAgent
{
    //Returns the furthest distance that the agent is able to attack from.
    void AttackDistance(float attackDistance);

    //Can the agent attack?
    void CanAttack(bool canAttack);

    //Returns the maximum angle that the agent can attack from.
    void AttackAngle(float attackAngle);

    //Does the actual attack.
    void Attack(Vector3 targetPosition);
}

public interface IItem
{

}

public interface IRarity
{

}

public interface IDurability
{

}