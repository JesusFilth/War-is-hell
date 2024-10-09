using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class WaveSpawner : MonoBehaviour
{
    protected const float DelaySpawn = 0.5f;

    [SerializeField] private List<EnemySpawnModel> _enemyModels;
    [SerializeField] private EnemySpawnPoint[] _points;
    [SerializeField] private int _capasity;
    [SerializeField] private bool _isUselevelSettings = true;
    [SerializeField] private float _experiance = 50;

    [Inject] private GameLevelCamera _camera;
    [Inject] private IGamePlayer _player;//?
    [Inject] private IGameLevel _gameLevel;
    [Inject] protected IGameLevelSettings Settings;//?

    protected bool HasEnemys => _enemysOnLine.Count > 0;
    protected int CountEnemysOnBattlefield => _enemysOnBattlefield.Count;

    protected Coroutine Executing;

    private Dictionary<Enemy, int> _enemysOnLine = new();
    private List<Enemy> _enemysOnBattlefield = new();

    private void OnValidate()
    {
        if (_enemyModels == null || _enemyModels.Count == 0)
            throw new ArgumentNullException(nameof(_enemyModels));

        if (_points == null || _points.Length == 0)
            throw new ArgumentNullException(nameof(_points));
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemysOnBattlefield)
            enemy.Died -= DieEnemy;

        if (Executing != null)
        {
            StopCoroutine(Executing);
            Executing = null;
        }
    }

    public void On()
    {
        _camera.Off();

        if(Executing==null)
            Executing = StartCoroutine(Execute());
    }

    public void Off()
    {
        _camera.On();

        AddExperiance();
        gameObject.SetActive(false);
    }

    protected abstract IEnumerator Execute();

    protected void Create()
    {
        if (HasEnemys == false)
            return;

        int randomIndex = Random.Range(0, _enemysOnLine.Count);
        var enemySpawn = _enemysOnLine.ElementAt(randomIndex);

        EnemySpawnPoint freePoint = GetRandomFreePoint();

        Enemy enemy = Instantiate(enemySpawn.Key, freePoint.Transform);
        freePoint.SetEnemy(enemy);
        enemy.Died += DieEnemy;
        _enemysOnBattlefield.Add(enemy);

        _enemysOnLine[enemySpawn.Key]--;

        if (_enemysOnLine[enemySpawn.Key] == 0)
            _enemysOnLine.Remove(enemySpawn.Key);
    }

    private void AddExperiance()
    {
        float percentUp = Settings.GetUpExceptionPercent();
        int level = _gameLevel.GetCurrentLevelNumber();
        float exp = (_experiance / 100) * (percentUp * level);
        _player.AddExpirience(exp);
        Debug.Log("Add exp");
    }

    private void Initialize()
    {
        float totalWeight = _enemyModels.Sum(spawnModel => spawnModel.Weight);

        foreach (EnemySpawnModel spawnModel in _enemyModels)
        {
            int count = (int)Mathf.Round(spawnModel.Weight / totalWeight * _capasity);

            if(count == 0)
                count = 1;

            _enemysOnLine.Add(spawnModel.Enemy, count);
        }
    }

    private EnemySpawnPoint GetRandomFreePoint()
    {
        EnemySpawnPoint[] freePoints = _points.Where(point => point.IsBusy == false).ToArray();

        if(freePoints == null || freePoints.Length == 0)
            throw new ArgumentNullException(nameof(freePoints));

        return freePoints[Random.Range(0, freePoints.Length)];
    }

    private void DieEnemy(Enemy enemy)
    {
        if (_enemysOnBattlefield.Contains(enemy) == false)
            throw new ArgumentNullException(nameof(enemy));

        enemy.Died -= DieEnemy;
        _enemysOnBattlefield.Remove(enemy);

        if (HasEnemys == false && CountEnemysOnBattlefield == 0)
        {
            Off();
            return;
        }

        if (HasEnemys)
        {
            if (Executing == null)
                Executing = StartCoroutine(Execute());
        }
    }
}