using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;
    [SerializeField] private Player _target;

    private State _currentState;

    private void Start()
    {
        _currentState = _startState;
        _currentState.enabled = true;
        _currentState.Init(_target);
    }

    private void Update()
    {
        foreach (Transition transition in _currentState.Transition)
        {
            if (transition.IsNeedTransist == true)
            {
                _currentState.Exit();
                _currentState.enabled = false;

                _currentState = transition.TargetState;
                _currentState.enabled = true;
                _currentState.Init(_target);

                break;
            }
        }
    }
}
