using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public abstract class RenderHealth : MonoBehaviour
{
    [SerializeField] protected HealthIndicator _healthIndicator;

    private void OnEnable()
    {
        _healthIndicator.TakedDamage += ChangeHealth;
        _healthIndicator.Recovered += ChangeHealth;
    }

    private void OnDisable()
    {
        _healthIndicator.TakedDamage -= ChangeHealth;
        _healthIndicator.Recovered -= ChangeHealth;
    }

    virtual protected void ChangeHealth(int newHealth)
    {
        
    }
}
