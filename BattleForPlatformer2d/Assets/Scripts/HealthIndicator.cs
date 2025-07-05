using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage) 
    {
        _health -= damage;

        if (_health <= 0)
            gameObject.SetActive(false);
    }

    public void Recovery(int recoverableHealth)
    {
        _health += recoverableHealth;
    }
}
