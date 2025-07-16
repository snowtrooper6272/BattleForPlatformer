using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _healthIndicator;
    [SerializeField] private float _findingRadius;
    [SerializeField] private float _delayOfFinding;

    private Coroutine _finding;
    private bool _isNeedFinding = true;
    private int _numberOfPlayerLayer = 7;

    public Player Target { get; private set; }

    private void OnEnable()
    {
        _healthIndicator.Died += Die;
        _finding = StartCoroutine(Finding());
    }

    private void OnDisable()
    {
        _healthIndicator.Died -= Die;
        StopCoroutine(_finding);
    }

    private IEnumerator Finding() 
    {
        WaitForSeconds delay = new WaitForSeconds(_delayOfFinding);

        while (_isNeedFinding) 
        {
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, _findingRadius, 1 << _numberOfPlayerLayer);

            foreach (Collider2D collision in collisions) 
            {
                if (collision.TryGetComponent(out Player player)) 
                {
                    Target = player;
                }
            }

            yield return delay;
        }
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
