using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public abstract class RenderHealth : MonoBehaviour
{
    [SerializeField] protected HealthIndicator HealthIndicator;

    private void OnEnable()
    {
        HealthIndicator.TakedDamage += ChangeHealth;
        HealthIndicator.Recovered += ChangeHealth;
    }

    private void OnDisable()
    {
        HealthIndicator.TakedDamage -= ChangeHealth;
        HealthIndicator.Recovered -= ChangeHealth;
    }

    virtual protected void ChangeHealth(int newHealth)
    {
        
    }
}
