using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected Transition[] _transitions;

    public event Action<State> Transited;
    public Transition[] Transition => _transitions;

    protected Player _target;

    public void OnEnable()
    {
        foreach (Transition transition in _transitions)
        {
            transition.enabled = true;
        }
    }

    private void OnDisable()
    {
        foreach (Transition transition in _transitions)
        {
            transition.enabled = false;
        }
    }

    private void LateUpdate()
    {
        foreach (Transition transition in Transition)
        {
            if (transition.IsNeedTransit == true)
            {
                Transited.Invoke(transition.TargetState);
            }
        }
    }

    public abstract void Init(Player target);

    public abstract void Exit();
}
