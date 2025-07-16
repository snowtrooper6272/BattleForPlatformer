using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _maxHealth;
    private int _minHealth = 0;

    public event Action Died;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage) 
    {
        if (damage > 0)
        {
            _health -= damage;

            _health = Mathf.Clamp(_health, _minHealth, _maxHealth);

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
