using UnityEngine;
using Transitions;
using States;
using Enemies;

public class ConvergenceTransition : Transition
{
    private Enemy _enemy;
    private int _distance;

    public ConvergenceTransition(State targetState, Enemy enemy, int distance) : base(targetState) 
    {
        _distance = distance;
        _enemy = enemy;
    }

    public override bool IsNeedTransit()
    {
        if (_enemy.FindTarget(_distance))
            return true;

        return false;
    }
}
