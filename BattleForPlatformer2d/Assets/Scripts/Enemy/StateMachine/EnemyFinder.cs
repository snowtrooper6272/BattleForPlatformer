using UnityEngine;

namespace ServiceStates
{
    public class EnemyFinder : MonoBehaviour
    {
        private int _distance = 22;
        public Player TrackTarget => FindTarget(_distance);

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
    }
}
