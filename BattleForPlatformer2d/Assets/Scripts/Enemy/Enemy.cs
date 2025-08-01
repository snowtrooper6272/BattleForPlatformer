using Interfaces;
using Scripts;
using Scripts.Factory;
using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(StateMachineFactory))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthIndicator _healthIndicator;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ControlPoint[] _patrolPoints;

        private StateMachine _stateMachine;
        private int _trackDistance = 22;

        private void OnEnable()
        {
            _healthIndicator.Died += Die;
        }

        private void OnDisable()
        {
            _healthIndicator.Died -= Die;
        }

        private void Start()
        {
            _stateMachine = GetComponent<StateMachineFactory>().Create(this, _patrolPoints);
        }

        private void Update()
        {
            _stateMachine.Update();
        }
        
        public void TakeDamage(int damage)
        {
            _healthIndicator.TakeDamage(damage);
        }

        public bool PatrolPointAssembled(ControlPoint target, float switchDistance)
        {
            Vector2 offset = target.transform.position - transform.position;

            return offset.sqrMagnitude <= switchDistance * switchDistance;
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
