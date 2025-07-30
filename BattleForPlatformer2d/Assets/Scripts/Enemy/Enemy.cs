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
        [SerializeField] private Health _healthIndicator;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ControlPoint[] _patrolPoints;

        private StateMachine _stateMachine;
        private int _trackDistance = 22;

        public Player TrackTarget => FindTarget();

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

        private Player FindTarget()
        {
            Player target = null;
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _trackDistance);

            foreach (var hit in hits) 
            {
                if (hit.TryGetComponent(out Player player))
                {
                    target = player;

                    break;
                }
            }

            return target;
        }

        public Player FindTarget(int distance) 
        {
            Player target = null;
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, distance);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out Player player))
                {
                    target = player;

                    break;
                }
            }

            return target;
        }

        public void TakeDamage(int damage)
        {
            _healthIndicator.TakeDamage(damage);
        }

        public void Move(Vector3 target, float speed) 
        {
            var direction = (target - transform.position).normalized;

            _rigidbody2D.velocity = direction * speed;
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
