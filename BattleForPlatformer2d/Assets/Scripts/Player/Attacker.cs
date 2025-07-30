using Enemies;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask attackLayer;

    private int _numberOfEnemyLayer = 8;

    public void Attack() 
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackLayer);

        foreach (Collider2D hit in hits) 
        {
            if (hit.gameObject.TryGetComponent(out Health target)) 
            {
                target.TakeDamage(_damage);
            }
        }
    }
}
