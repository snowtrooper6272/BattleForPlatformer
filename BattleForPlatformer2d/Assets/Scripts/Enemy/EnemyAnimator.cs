using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly string _attack = "Attack";

    public void PlayAttack() 
    {
        _animator.Play(_attack);
    }
}
