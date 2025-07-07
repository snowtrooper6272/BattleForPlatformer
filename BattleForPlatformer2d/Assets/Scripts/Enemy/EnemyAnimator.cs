using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _isAttack = Animator.StringToHash(nameof(_isAttack));

    public void PlayAttack() 
    {
        _animator.SetBool(_isAttack, true);
    }

    public void StopAttack() 
    {
        _animator.SetBool(_isAttack, false);
    }
}
