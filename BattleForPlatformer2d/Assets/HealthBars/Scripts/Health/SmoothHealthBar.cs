using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;
using System;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _timeSmoothChange;

    private Coroutine _smoothChangingValue;

    private void Start()
    {
        _slider.value = Convert.ToSingle(HealthIndicator.Health) / Convert.ToSingle(HealthIndicator.MaxHealth);
    }

    override protected void ChangeHealth(int newHealth)
    {
        if(_smoothChangingValue != null)
            StopCoroutine(_smoothChangingValue);

        _smoothChangingValue = StartCoroutine(SmoothChangingValue(newHealth));
    }

    private IEnumerator SmoothChangingValue(int newHealth) 
    {
        float currentTime = 0f;
        float targetValue = Convert.ToSingle(newHealth) / Convert.ToSingle(HealthIndicator.MaxHealth);
        float startSliderPosition = _slider.value;

        while (currentTime < _timeSmoothChange) 
        {
            currentTime += Time.deltaTime;
            float normalizedPosition = currentTime / _timeSmoothChange;

            _slider.value = Mathf.Lerp(startSliderPosition, targetValue, normalizedPosition);

            yield return null;
        }
    }
}
