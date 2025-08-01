using UnityEngine;

namespace ServiceStates
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public void Move(Vector3 target, float speed)
        {
            var direction = (target - transform.position).normalized;

            _rigidbody2D.velocity = direction * speed;
        }
    }
}
