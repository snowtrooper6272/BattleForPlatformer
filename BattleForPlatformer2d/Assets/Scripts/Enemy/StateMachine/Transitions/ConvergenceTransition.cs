using UnityEngine;
using Transitions;
using ServiceStates;
using States;
using Enemies;

public class ConvergenceTransition : Transition
{
    private Enemy _enemy;
    private EnemyFinder _finder;
    private int _distance;

    public ConvergenceTransition(State targetState, Enemy enemy, EnemyFinder finder, int distance) : base(targetState) 
    {
        _distance = distance;
        _enemy = enemy;
        _finder = finder;
    }

    public override bool IsNeedTransit()
    {
        if (_finder.FindTarget(_distance))
            return true;

        return false;
    }
}
