using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;

    public event Action Grounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int countGroundContacts = 0;

        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            if (contactPoint.collider.gameObject.TryGetComponent(out Ground ground))
            {
                countGroundContacts++;
                break;
            }
        }

        if (countGroundContacts > 0)
            Grounded.Invoke();
    }
}
