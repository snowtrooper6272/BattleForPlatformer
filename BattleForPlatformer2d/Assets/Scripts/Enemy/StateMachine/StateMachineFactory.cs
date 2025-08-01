using UnityEngine;
using Enemies;
using States;
using Transitions;
using System.Collections.Generic;
using ServiceStates;

namespace Scripts.Factory {
    public class StateMachineFactory : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private EnemyMover _mover;
        [SerializeField] private EnemyFinder _finder;

        public StateMachine Create(Enemy enemy, ControlPoint[] controlPoints) 
        {
            List<Transition> patrolTransitions = new List<Transition>(0);
            List<Transition> followTransitions = new List<Transition>(0);
            List<Transition> attackTransitions = new List<Transition>(0);

            PatrolState patrolState = new PatrolState(patrolTransitions, enemy, controlPoints, _mover);
            FollowState followState = new FollowState(followTransitions, enemy, _finder, _mover);
            AttackState attackState = new AttackState(attackTransitions, enemy, _animator, _finder);

            patrolTransitions.Add(new ConvergenceTransition(followState, enemy, _finder, 20));
            followTransitions.Add(new ConvergenceTransition(attackState, enemy, _finder, 5));
            followTransitions.Add(new AlienationTransition(patrolState, enemy, _finder, 22));
            attackTransitions.Add(new AlienationTransition(followState, enemy, _finder, 6));

            var stateMachine = new StateMachine(patrolState);
            return stateMachine;
        }
    }
}
