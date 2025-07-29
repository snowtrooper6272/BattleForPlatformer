using Interfaces;
using Scripts;
using Scripts.Factory;
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

        private void OnEnable()
        {
            _healthIndicator.Died += Die;
        }

        private void OnDisable()
        {
            _healthIndicator.Died -= Die;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void Init(Player player) // откдуа?
        {
            _stateMachine = GetComponent<StateMachineFactory>().Create(this, player, _patrolPoints);
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
