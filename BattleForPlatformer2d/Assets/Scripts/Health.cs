using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    public event Action Died;

    public void TakeDamage(int damage) 
    {
        if (damage > 0)
        {
            _health -= damage;

            if (_health <= 0)
                Died.Invoke();
        }
    }

    public void Recovery(int recoverableHealth)
    {
        if(recoverableHealth > 0)
            _health += recoverableHealth;
    }
}
