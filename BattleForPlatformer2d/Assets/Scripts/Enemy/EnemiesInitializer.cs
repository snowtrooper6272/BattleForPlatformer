using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInitializer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy[] _enemies;

    private void Start()
    {
        foreach (var enemy in _enemies)
            enemy.Init(player);
    }
}
