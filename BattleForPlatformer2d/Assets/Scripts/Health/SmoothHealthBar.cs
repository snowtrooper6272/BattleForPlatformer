using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;
using System;

public class SmoothHealthBar : MonoBehaviour, IHealthChangeable
{
    [SerializeField] private HealthIndicator _healthIndicator;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _timeSmoothChange;

    private Coroutine _smoothChangingValue;

    private void OnEnable()
    {
        _healthIndicator.TakedDamage += ChangeHealth;
        _healthIndicator.Recovered += ChangeHealth;
    }

    private void OnDisable()
    {
        _healthIndicator.TakedDamage -= ChangeHealth;
        _healthIndicator.Recovered -= ChangeHealth;
        StopCoroutine(_smoothChangingValue);
    }

    public void ChangeHealth(int newHealth)
    {
        if(_smoothChangingValue != null)
            StopCoroutine(_smoothChangingValue);

        _smoothChangingValue = StartCoroutine(SmoothChangingValue(newHealth));
    }

    private IEnumerator SmoothChangingValue(int newHealth) 
    {
        float currentTime = 0f;
        float targetValue = Convert.ToSingle(newHealth) / Convert.ToSingle(_healthIndicator.MaxHealth);

        while (currentTime < _timeSmoothChange) 
        {
            currentTime += Time.deltaTime;
            float normalizedPosition = currentTime / _timeSmoothChange;

            _slider.value = Mathf.Lerp(_slider.value, targetValue, normalizedPosition);

            yield return null;
        }
    }
}
