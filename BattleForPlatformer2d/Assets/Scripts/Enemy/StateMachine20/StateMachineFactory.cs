using UnityEngine;
using Enemies;
using States;
using Transitions;
using System.Collections.Generic;

namespace Scripts.Factory {
    public class StateMachineFactory : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;

        public StateMachine Create(Enemy enemy, Player player, ControlPoint[] controlPoints) 
        {
            List<Transition> patrolTransitions = new List<Transition>(0);
            List<Transition> followTransitions = new List<Transition>(0);
            List<Transition> attackTransitions = new List<Transition>(0);

            PatrolState patrolState = new PatrolState(patrolTransitions, enemy, controlPoints);
            FollowState followState = new FollowState(followTransitions, enemy, player);
            AttackState attackState = new AttackState(attackTransitions, enemy, player, _animator);

            patrolTransitions.Add(new ConvergenceTransition(followState, player, enemy, 20));
            followTransitions.Add(new ConvergenceTransition(attackState, player, enemy, 5));
            followTransitions.Add(new AlienationTransition(patrolState, player, enemy, 22));
            attackTransitions.Add(new AlienationTransition(followState, player, enemy, 6));

            var stateMachine = new StateMachine(patrolState);

            return stateMachine;
        }
    }
}
