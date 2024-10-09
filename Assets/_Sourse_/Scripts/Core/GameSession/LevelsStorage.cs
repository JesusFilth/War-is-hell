using System;
using UnityEngine;

public class LevelsStorage : MonoBehaviour,
    ILevelsStorage,
    IGameLevelSettings
{
    [SerializeField] private LevelLocation[] _levels;
    [SerializeField] private Player _playerPrefab;//?
    [SerializeField] private LevelSettings _levelSettings;

    public LevelLocation GetLevelLocation(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == _levels.Length)
            index = 0;

        return _levels[index];
    }

    public Player GetPlayerPrefab() => _playerPrefab;//?

    public LevelSettings GetLevelSettings() => _levelSettings;

    public float GetUpEnemyStat() => _levelSettings.UpEnemyStatForLevel;

    public int GetMinWaveSize() => _levelSettings.MinWaveSize;

    public int GetMaxWaveSize() => _levelSettings.MaxWaveSize;

    public int GetMinSquadEnemy() => _levelSettings.MinSquadEnemy;

    public int GetMaxSquadEnemy() => _levelSettings.MaxSquadEnemy;

    public int GetMinPermonentEnemy() => _levelSettings.MinPermonentEnemy;

    public int GetMaxPermonentEnemy() => _levelSettings.MaxPermonentEnemy;

    public float GetUpExceptionPercent() => _levelSettings.UpExeptionPercentForLevel;
}