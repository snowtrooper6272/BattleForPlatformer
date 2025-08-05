using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interfaces;
using System;

public class HealthBar : MonoBehaviour, IHealthChangeable
{
    [SerializeField] private HealthIndicator _healthIndicator;
    [SerializeField] private Slider _slider;

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

    public void ChangeHealth(int newHealth)
    {
        _slider.value = Convert.ToSingle(newHealth) / Convert.ToSingle(_healthIndicator.MaxHealth);
    }
}
