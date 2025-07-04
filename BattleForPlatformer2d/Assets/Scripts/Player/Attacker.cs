using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _frequency;

    private Enemy _target;
    private Coroutine _attacking;

    public event Action<bool> Attacked;

    private void OnEnable()
    {
        _attacking = StartCoroutine(Attack());
    }

    private void OnDisable()
    {
        StopCoroutine(_attacking);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Attacked.Invoke(true);
            _target = enemy;
            _attacking = StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Attacked.Invoke(false);
            _target = null;
            StopCoroutine(_attacking);
        }
    }

    private IEnumerator Attack() 
    {
        WaitForSeconds delay = new WaitForSeconds(_frequency);

        while (_target != null) 
        {
            _target.TakeDamage(_damage);

            yield return delay;
        }
    }
}
