using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _healthIndicator;

    private void OnEnable()
    {
        _healthIndicator.Died += Die;
    }

    private void OnDisable()
    {
        _healthIndicator.Died -= Die;
    }

    public void TakeDamage(int damage)
    {
        _healthIndicator.TakeDamage(damage);
    }

    private void Die() 
    {
        gameObject.SetActive(false);
    }
}
