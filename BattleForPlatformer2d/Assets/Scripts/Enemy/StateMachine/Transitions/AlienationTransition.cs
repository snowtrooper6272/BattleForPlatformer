using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienationTransition : Transition
{
    [SerializeField] private float _checkDelay;
    [SerializeField] private float _checkRadius;

    private Coroutine _checking;

    private void OnEnable()
    {
        IsNeedTransit = false;
        _checking = StartCoroutine(Checking());
    }

    private void OnDisable()
    {
        if(_checking != null)
            StopCoroutine(_checking);
    }

    private IEnumerator Checking()
    {
        WaitForSeconds delay = new WaitForSeconds(_checkDelay);

        while (IsNeedTransit == false)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _checkRadius, transform.forward);
            Player target = null;

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent(out Player player))
                {
                    target = player;
                }
            }

            if (target == null) 
            {
                IsNeedTransit = true;
            }

            yield return delay;
        }
    }
}
