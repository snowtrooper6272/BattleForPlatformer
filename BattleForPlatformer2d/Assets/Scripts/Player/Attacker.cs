using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;

    private int _numberOfEnemyLayer = 8;

    public void Attack() 
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius, 1 << _numberOfEnemyLayer);

        foreach (Collider2D hit in hits) 
        {
            if (hit.gameObject.TryGetComponent(out Enemy target)) 
            {
                target.TakeDamage(_damage);
            }
        }
    }
}
