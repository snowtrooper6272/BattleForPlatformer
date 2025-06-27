using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHealthPacks : MonoBehaviour
{
    [SerializeField] private int _maxHealthPackCoin;
    [SerializeField] private HealthPack _prefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform[] _spawnAreas;

    private List<HealthPack> _healthPacksPool = new List<HealthPack>();
    private List<HealthPack> _activeHealthPacksPool = new List<HealthPack>();
    private Coroutine _spawning;

    private void OnEnable()
    {
        _spawning = StartCoroutine(Spawning());

        foreach (HealthPack healthPack in _activeHealthPacksPool)
        {
            healthPack.Matched += PlaceCoinInPool;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < _maxHealthPackCoin; i++)
        {
            HealthPack healthPack = Instantiate(_prefab);
            healthPack.gameObject.SetActive(false);
            _healthPacksPool.Add(healthPack);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_spawning);

        foreach (HealthPack healthPack in _activeHealthPacksPool)
        {
            healthPack.Matched -= PlaceCoinInPool;
        }
    }

    private IEnumerator Spawning()
    {
        bool isNeedGenerate = true;
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while (isNeedGenerate)
        {
            if (_healthPacksPool.Count > 0)
                Appearance(_healthPacksPool[Random.Range(0, _healthPacksPool.Count)], _spawnAreas[Random.Range(0, _spawnAreas.Length)].transform);

            yield return delay;
        }
    }

    public void PlaceCoinInPool(HealthPack healthPack)
    {
        if (_activeHealthPacksPool.Contains(healthPack))
        {
            _activeHealthPacksPool.Remove(healthPack);
            _healthPacksPool.Add(healthPack);
            healthPack.Matched -= PlaceCoinInPool;
            healthPack.gameObject.SetActive(false);
        }
    }

    private void Appearance(HealthPack removeHealthPack, Transform spawnArea)
    {
        removeHealthPack.Matched += PlaceCoinInPool;
        removeHealthPack.transform.position = new Vector3(Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2), spawnArea.position.y);
        removeHealthPack.gameObject.SetActive(true);

        _healthPacksPool.Remove(removeHealthPack);
        _activeHealthPacksPool.Add(removeHealthPack);
    }
}
