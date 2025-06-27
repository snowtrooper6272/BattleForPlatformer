using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private PickUperHealthPacks _pickUperHealthPacks;
    [SerializeField] private int _health;

    private void OnEnable()
    {
        _groundChecker.Grounded += SetGrounded;
        _attacker.Attacked += SetAttackMode;
        _pickUperHealthPacks.Matched += Recovery;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= SetGrounded;
        _attacker.Attacked -= SetAttackMode;
        _pickUperHealthPacks.Matched -= Recovery;
    }

    private void Update()
    {
        _animator.PlayRun(_inputReader.AxisDirection, _mover.MoveSpeed);
        _flipper.Flip(_inputReader.AxisDirection);
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputReader.AxisDirection);

        if (_inputReader.IsJumpKeyDown && _jumper.IsPossibleJump)
        {
            _jumper.Jump();
            _animator.PlayJump();
            _inputReader.Jump();
        }
    }

    private void SetGrounded()
    {
        _animator.Aterrissagem();
        _jumper.SetGrounded();
    }

    private void SetAttackMode(bool isEnable)
    {
        _animator.SetAttack(isEnable);
    }

    public void TakeDamage(int damage) 
    {
        _health -= damage;

        if (_health <= 0)
            gameObject.SetActive(false);
    }

    private void Recovery(int recoverableHealth) 
    {
        _health += recoverableHealth;
    }
}
