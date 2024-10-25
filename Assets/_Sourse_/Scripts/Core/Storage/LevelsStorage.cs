using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelsStorage : MonoBehaviour,
    ILevelsStorage,
    IGameLevelSettings,
    IHeroStorage
{
    [SerializeField] private LevelLocation[] _levels;
    [SerializeField] private List<HeroSetting> _heroes;
    [SerializeField] private LevelSettings _levelSettings;//?
    [SerializeField] private Player _playerPrefab;//?

    private HeroSetting _currentHero;

    public LevelLocation GetLevelLocation(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == _levels.Length)
            index = 0;

        return _levels[index];
    }

    public Player GetPlayerPrefab() => _playerPrefab;//?

    public void SetCurrentHero(HeroSetting heroSetting)
    {
        _currentHero = heroSetting;
    }

    public HeroSetting GetCurrentHero() => _currentHero;

    public IReadOnlyList<HeroSetting> GetHeroes() => _heroes;

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