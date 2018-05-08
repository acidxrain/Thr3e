using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
    {
        // Take damage by the specified amount.
        void Damage(float amout);

        // Is the object currently alive?
        bool IsAlive();
    }