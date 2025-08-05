using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _maxHealth = 20;
    private int _minHealth = 0;

    public event Action Died;
    public event Action<int> TakedDamage;
    public event Action<int> Recovered;
    public int MaxHealth => _maxHealth;
    public int Health => _health;

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        if (damage > 0)
        {
            _health -= damage;

            _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
            TakedDamage.Invoke(_health);

            if (_health <= 0)
                Died.Invoke();
        }
    }

    public void Recovery(int recoverableHealth)
    {
        if (recoverableHealth > 0)
        {
            _health += recoverableHealth;

            _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
            Recovered.Invoke(_health);
        }
    }
}
