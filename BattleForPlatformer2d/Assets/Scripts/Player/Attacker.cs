using Enemies;
using Interfaces;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _attackLayer;

    public void Attack()
    { 
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius, _attackLayer);

        foreach (Collider2D hit in hits) 
        {
            if (hit.TryGetComponent(out Player player) == false)
            {
                hit.TryGetComponent(out IDamageable damageable);
                damageable?.TakeDamage(_damage);
            }
        }
    }
}
