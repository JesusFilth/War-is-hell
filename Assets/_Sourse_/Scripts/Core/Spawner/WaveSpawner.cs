using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class WaveSpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnModel[] _enemyModels;
    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private int _capasity;
    [SerializeField] private float _experiance = 50;

    [Inject] private FollowCameraToPlayerX _camera;
    [Inject] private IGamePlayer _player;
    [Inject] private IGameProgress _gameProgress;

    protected bool HasEnemys => _enemysOnLine.Count > 0;
    protected int CountEnemysOnBattlefield => _enemysOnBattlefield.Count;

    private Dictionary<string, int> _enemysOnLine = new();
    private List<Enemy> _enemysOnBattlefield = new();

    private void OnValidate()
    {
        if (_enemyModels == null || _enemyModels.Length == 0)
            throw new ArgumentNullException(nameof(_enemyModels));

        if (_points == null || _points.Length == 0)
            throw new ArgumentNullException(nameof(_points));
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemysOnBattlefield)
            enemy.Died -= DieEnemy;
    }

    private void OnDestroy()
    {
        _enemysOnLine = null;
        _enemysOnBattlefield = null;
        _enemyModels = null;
        _points = null;
    }

    public void On()
    {
        _camera.Off();
        Initialize();
        Execute();
    }

    public void Off()
    {
        _camera.On();

        AddExperiance();
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        //gameObject.SetActive(false);

        //StartCoroutine(Destroying());//?
    }

    protected abstract void Execute();

    protected void Create()
    {
        if (HasEnemys == false)
            return;

        int randomIndex = Random.Range(0, _enemysOnLine.Count);
        var enemySpawn = _enemysOnLine.ElementAt(randomIndex);

        SpawnPoint freePoint = GetRandomFreePoint();

        //Enemy enemy = Instantiate(enemySpawn.Key, freePoint.Transform);//?

        Enemy enemy = Resources.Load<Enemy>($"Enemys/{enemySpawn.Key}");//?
        enemy = Instantiate(enemy, freePoint.Transform);

        freePoint.SetEnemy(enemy);
        enemy.Died += DieEnemy;
        _enemysOnBattlefield.Add(enemy);

        _enemysOnLine[enemySpawn.Key]--;

        if (_enemysOnLine[enemySpawn.Key] == 0)
            _enemysOnLine.Remove(enemySpawn.Key);
    }

    private IEnumerator Destroying()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
    }

    private void AddExperiance()
    {
        //int level = _gameProgress.GetPlayerProgress().LevelCount;
        //float exp = (_experiance / 100) * (percentUp * level);
        //_player.AddExpirience(exp);
    }

    private void Initialize()
    {
        float totalWeight = _enemyModels.Sum(spawnModel => spawnModel.Weight);

        foreach (EnemySpawnModel spawnModel in _enemyModels)
        {
            int count = (int)Mathf.Round(spawnModel.Weight / totalWeight * _capasity);
            _enemysOnLine.Add(spawnModel.Enemy, count);
        }
    }

    private SpawnPoint GetRandomFreePoint()
    {
        SpawnPoint[] freePoints = _points.Where(point => point.IsBusy == false).ToArray();

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

        if(HasEnemys)
            Execute();
    }
}