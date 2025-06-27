using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUperHealthPacks : MonoBehaviour
{
    public event Action<int> Matched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out HealthPack healthPack))
        {
            healthPack.PickUp();
            Matched.Invoke(healthPack.HealthRecovery);
        }
    }
}
