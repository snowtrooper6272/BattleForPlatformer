using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _recoveryButton;

    private int _maxHealth = 20;
    private int _minHealth = 0;
    private int _buttonDamage = 2;
    private int _buttonRecovery = 2;

    public event Action Died;
    public event Action<int> TakedDamage;
    public event Action<int> Recovered;
    public int MaxHealth => _maxHealth;
    public int Health => _health;

    private void OnEnable()
    {
        _health = _maxHealth;
        _damageButton?.onClick.AddListener(() => TakeDamage(_buttonDamage));
        _recoveryButton?.onClick.AddListener(() => Recovery(_buttonRecovery));
    }

    private void OnDisable()
    {
        _damageButton?.onClick.RemoveListener(() => TakeDamage(_buttonDamage));
        _recoveryButton?.onClick.RemoveListener(() => Recovery(_buttonRecovery));
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
