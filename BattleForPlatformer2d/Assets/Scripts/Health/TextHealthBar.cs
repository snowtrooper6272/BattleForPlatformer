using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Interfaces;

public class TextHealthBar : MonoBehaviour, IHealthChangeable
{
    [SerializeField] private HealthIndicator _healthIndicator;
    [SerializeField] private TMP_Text _currentHealth;
    [SerializeField] private TMP_Text _maxHealth;

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

    private void Start()
    {
        _maxHealth.text = _healthIndicator.MaxHealth.ToString();
        _currentHealth.text = _healthIndicator.Health.ToString();
    }

    public void ChangeHealth(int newHealth) 
    {
        _currentHealth.text = newHealth.ToString();
    }
}
