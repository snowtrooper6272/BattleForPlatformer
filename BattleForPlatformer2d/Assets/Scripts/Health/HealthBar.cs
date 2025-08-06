using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interfaces;
using System;

public class HealthBar : RenderHealth
{
    [SerializeField] private Slider _slider;

    override protected void ChangeHealth(int newHealth)
    {
        _slider.value = Convert.ToSingle(newHealth) / Convert.ToSingle(_healthIndicator.MaxHealth);
    }
}
