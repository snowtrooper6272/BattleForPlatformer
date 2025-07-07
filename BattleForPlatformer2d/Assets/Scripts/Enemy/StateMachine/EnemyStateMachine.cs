using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;
    [SerializeField] private Player _target;

    private State _currentState;

    private void OnEnable()
    {
        _currentState = _startState;
        _currentState.Transited += ChangeState;
    }

    private void OnDisable()
    {
        _currentState.Transited -= ChangeState;
    }

    private void Start()
    {
        _currentState.enabled = true;
        _currentState.Init(_target);
    }

    private void ChangeState(State targetState) 
    {
        _currentState.Transited -= ChangeState;
        _currentState.Exit();
        _currentState.enabled = false;

        _currentState = targetState;
        _currentState.enabled = true;
        _currentState.Init(_target);
        _currentState.Transited += ChangeState;
    }
}
