using System.Collections.Generic;
using UnityEngine;

public class SkillsEnemyConteiner : MonoBehaviour
{
    public IReadOnlyCollection<Enemy> Enemys => _enemys;

    public bool HasEnemys   => _enemys.Count > 0;

    private List<Enemy> _enemys = new();

    private void Update()
    {
        Debug.Log("Counts: "+ _enemys.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.IsDead)
                return;

            AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.IsDead)
                return;

            RemoveEnemy(enemy);
        }
    }

    private void AddEnemy(Enemy enemy)
    {
        _enemys.Add(enemy);
        enemy.Died += DieEnemy;
    }

    private void RemoveEnemy(Enemy enemy)
    {
        if (_enemys.Contains(enemy))
        {
            enemy.Died -= DieEnemy;
            _enemys.Remove(enemy);
        }
    }

    private void DieEnemy(Enemy enemy)
    {
        RemoveEnemy(enemy);
    }
}