using UnityEngine;
using Enemies;
using States;
using Transitions;
using System.Collections.Generic;

namespace Scripts.Factory {
    public class StateMachineFactory : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;

        public StateMachine Create(Enemy enemy, ControlPoint[] controlPoints) 
        {
            List<Transition> patrolTransitions = new List<Transition>(0);
            List<Transition> followTransitions = new List<Transition>(0);
            List<Transition> attackTransitions = new List<Transition>(0);

            PatrolState patrolState = new PatrolState(patrolTransitions, enemy, controlPoints);
            FollowState followState = new FollowState(followTransitions, enemy);
            AttackState attackState = new AttackState(attackTransitions, enemy, _animator);

            patrolTransitions.Add(new ConvergenceTransition(followState, enemy, 20));
            followTransitions.Add(new ConvergenceTransition(attackState, enemy, 5));
            followTransitions.Add(new AlienationTransition(patrolState, enemy, 22));
            attackTransitions.Add(new AlienationTransition(followState, enemy, 6));

            var stateMachine = new StateMachine(patrolState);

            return stateMachine;
        }
    }
}
