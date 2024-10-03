using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevelStorage : MonoBehaviour,
    IGameLevels,
    IGamePlayer,
    IGameProgress,
    IPlayerAbilities,
    IGameLevelSettings
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private LevelSettings _levelSettings;

    private Player _player;
    private LevelLocation _currentLevel;

    private string[] _levelNames = new string[] 
    {
        "Levels/Level_1.1",
        "Levels/Level_1.2",
    };

    public void LoadGameLevel(Skill skill = null)
    {
        Skill currentSkill = skill;

        if(_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
            Resources.UnloadUnusedAssets();
        }

        _currentLevel = GetLoadLocation();
        _currentLevel.SetPriseSkill(currentSkill);

        InitPlayer(_currentLevel.PlayerStartPosition.position);

        _player.Progress.AddLevel();
    }

    private LevelLocation GetLoadLocation()
    {
        int index = Random.Range(0, _levelNames.Length);
        LevelLocation levelLocation = Resources.Load<LevelLocation>(_levelNames[index]);

        return Instantiate(levelLocation);
    }

    public void InitPlayer(Vector3 position)
    {
        if(_player == null)
        {
            _player = Instantiate(_playerPrefab);
        }
        
        _player.SetPosition(position);
    }

    public void DestroyPlayer()
    {
        if(_player != null)
        {
            Destroy(_player.gameObject);
        }
    }

    public Transform GetPlayerPosition()
    {
        if (_player == null)
            throw new ArgumentNullException(nameof(_player));

        return _player.Transform;
    }

    public void AddExpirience(float exp)
    {
        _player.AddExperience(exp);
    }

    public void Resurrect()
    {
        _player.Abilitys.Resurrect();
    }

    public PlayerProgress GetPlayerProgress()
    {
        if (_player == null)
            return null;

        return _player.Progress;
    }

    public PlayerAbilitys GetAbilities()
    {
        if (_player == null)
            throw new ArgumentNullException(nameof(_player));

        return _player.Abilitys;
    }

    public float GetUpEnemyStat() => _levelSettings.UpEnemyStatForLevel;

    public int GetMinWaveSize() => _levelSettings.MinWaveSize;

    public int GetMaxWaveSize() => _levelSettings.MaxWaveSize;

    public int GetMinSquadEnemy() => _levelSettings.MinSquadEnemy;

    public int GetMaxSquadEnemy() => _levelSettings.MaxSquadEnemy;

    public int GetMinPermonentEnemy() => _levelSettings.MinPermonentEnemy;

    public int GetMaxPermonentEnemy() => _levelSettings.MaxPermonentEnemy;

    public float GetUpExceptionPercent() => _levelSettings.UpExeptionPercentForLevel;

    private IEnumerator PlayerToStarting()
    {
        yield return new WaitForSeconds(0.5f);
        InitPlayer(_currentLevel.PlayerStartPosition.position);
    }
}