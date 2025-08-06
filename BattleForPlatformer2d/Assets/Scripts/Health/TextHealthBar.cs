using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Interfaces;

public class TextHealthBar : RenderHealth
{
    [SerializeField] private TMP_Text _currentHealth;
    [SerializeField] private TMP_Text _maxHealth;

    private void Start()
    {
        _maxHealth.text = _healthIndicator.MaxHealth.ToString();
        _currentHealth.text = _healthIndicator.Health.ToString();
    }

    override protected void ChangeHealth(int newHealth) 
    {
        _currentHealth.text = newHealth.ToString();
    }
}
