using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _speed = Animator.StringToHash(nameof(_speed));
    private readonly int _isJump = Animator.StringToHash(nameof(_isJump));
    private readonly int _isAttack = Animator.StringToHash(nameof(_isAttack));

    public void PlayRun(float axisDirection, float speed) 
    {
        if (axisDirection < 0 || axisDirection > 0)
            _animator.SetFloat(_speed, Mathf.Abs(axisDirection) * speed);
        else
            _animator.SetFloat(_speed, 0);
    }

    public void PlayAttack() 
    {
        _animator.SetBool(_isAttack, true);
    }

    public void StopAttack() 
    {
        _animator.SetBool(_isAttack, false);
    }

    public void PlayJump() 
    {
        _animator.SetBool(_isJump, true);
    }

    public void SetGrounded() 
    {
        _animator.SetBool(_isJump, false);
    }
}