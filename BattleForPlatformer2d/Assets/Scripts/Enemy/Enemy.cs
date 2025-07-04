using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyHealthIndicator _healthIndicator;

    public void TakeDamage(int damage)
    {
        _healthIndicator.TakeDamage(damage);
    }
}
