using System.Collections.Generic;
using UnityEngine;

namespace Characters.Player
{
    public class SkillsEnemyConteiner : MonoBehaviour
    {
        public IReadOnlyCollection<Enemy> Enemys => _enemys;

        public bool HasEnemys => _enemys.Count > 0;

        private List<Enemy> _enemys = new();

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
            {
                AddEnemy(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
            {
                RemoveEnemy(enemy);
            }
        }

        private void AddEnemy(Enemy enemy)
        {
            _enemys.Add(enemy);
            enemy.Destroed += RemoveEnemy;
        }

        private void RemoveEnemy(Enemy enemy)
        {
            if (_enemys.Contains(enemy))
            {
                _enemys.Remove(enemy);
                enemy.Destroed -= RemoveEnemy;
            }
        }
    }
}