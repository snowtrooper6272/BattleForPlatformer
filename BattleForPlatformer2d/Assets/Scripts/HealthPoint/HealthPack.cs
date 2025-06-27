using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int _healthRecovery;

    public event Action<HealthPack> Matched;

    public int HealthRecovery => _healthRecovery;

    public void PickUp() 
    {
        Matched.Invoke(this);
    }
}
