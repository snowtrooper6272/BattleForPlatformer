using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interfaces;
using System;

public class HealthBar : RenderHealth
{
    [SerializeField] protected Slider _slider;

    private void Start()
    {
        ChangeHealth(HealthIndicator.Health);
    }

    override protected void ChangeHealth(int newHealth)
    {
        _slider.value = Convert.ToSingle(newHealth) / Convert.ToSingle(HealthIndicator.MaxHealth);
    }
}
