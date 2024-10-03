using System;
using UnityEngine;

[Serializable]
public class EnemySpawnModel
{
    [SerializeField] private string _enemy;
    [SerializeField] [Range(1, 100)] private float _weight = 50f;

    public string Enemy => _enemy;
    public float Weight => _weight;
}
