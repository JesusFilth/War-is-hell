using System;
using Characters;
using UnityEngine;

namespace Core.Spawner.EnemyWaves
{
    [Serializable]
    public class EnemySpawnModel
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] [Range(1, 100)] private float _weight = 50f;

        public Enemy Enemy => _enemy;
        public float Weight => _weight;
    }
}
