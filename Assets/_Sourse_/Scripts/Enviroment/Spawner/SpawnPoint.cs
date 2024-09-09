using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsBusy { get; private set; } = false;
    public Transform Transform { get; private set; }

    private Enemy _currentEnemy;

    private void Awake()
    {
        Transform = transform;
    }

    private void OnDisable()
    {
        if (_currentEnemy != null)
            _currentEnemy.Died -= DieEnemy;
    }

    public void SetEnemy(Enemy enemy)
    {
        IsBusy = true;
        _currentEnemy = enemy;
        _currentEnemy.Died += DieEnemy;
    }

    private void DieEnemy(Enemy enemy)
    {
        IsBusy = false;
        enemy.Died -= DieEnemy;

        _currentEnemy = null;
    }
}