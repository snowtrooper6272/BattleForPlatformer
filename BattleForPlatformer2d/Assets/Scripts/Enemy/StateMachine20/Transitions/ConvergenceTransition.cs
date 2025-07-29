using UnityEngine;
using Transitions;
using States;
using Enemies;

public class ConvergenceTransition : Transition
{
    private Player _target;
    private Enemy _enemy;
    private float _distance;

    public ConvergenceTransition(State targetState, Player target, Enemy enemy, float distance) : base(targetState) 
    {
        _distance = distance;
        _target = target;
        _enemy = enemy;
    }

    public override bool IsNeedTransit()
    {
        if ((_target.transform.position - _enemy.transform.position).sqrMagnitude <= _distance * _distance)
            return true;

        return false;
    }
}
