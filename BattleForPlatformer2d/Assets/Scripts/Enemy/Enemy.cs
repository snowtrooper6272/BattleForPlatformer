using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthIndicator _healthIndicator;

    public void TakeDamage(int damage)
    {
        _healthIndicator.TakeDamage(damage);
    }
}
