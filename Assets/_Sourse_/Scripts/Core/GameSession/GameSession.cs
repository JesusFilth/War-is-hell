using Reflex.Attributes;
using System;
using UnityEngine;

public class GameSession : MonoBehaviour,
    IGameLevels,
    IGamePlayer,//?
    IGameProgress,//?
    IPlayerAbilities,//?
    IGameLevelSettings
{
    private Player _player;
    private LevelLocation _currentLevel;
    private int _currentNumberLevel = 1;

    [Inject] private LevelsStorage _levelsStorage;

    private void OnDestroy()
    {
        if (_player != null)
        {
            Destroy(_player.gameObject);
        }
    }

    public void StartGame()
    {
        _currentLevel = Instantiate(_levelsStorage.GetLevelLocation(_currentNumberLevel-1));
        InitPlayer(_currentLevel.PlayerStartPosition.position);
        _player.Progress.SetLevelNumber(_currentNumberLevel);
    }

    public void LoadNextLevel(Skill skill = null)
    {
        _currentNumberLevel++;
        _player.Progress.SetLevelNumber(_currentNumberLevel);

        if (_currentLevel != null)
            Destroy(_currentLevel.gameObject);

        _currentLevel = Instantiate(_levelsStorage.GetLevelLocation(_currentNumberLevel - 1));
        _currentLevel.SetPriseSkill(skill);
    }

    public void InitPlayer(Vector3 position)
    {
        if (_player == null)
            _player = Instantiate(_levelsStorage.GetPlayerPrefab());

        _player.SetPosition(position);
    }

    public Transform GetPlayerPosition()//?
    {
        if (_player == null)
            throw new ArgumentNullException(nameof(_player));

        return _player.Transform;
    }

    public void AddExpirience(float exp)//?
    {
        _player.AddExperience(exp);
    }

    public void Resurrect()//?
    {
        _player.Abilitys.Resurrect();
    }

    public PlayerProgress GetPlayerProgress()//?
    {
        if (_player == null)
            return null;

        return _player.Progress;
    }

    public PlayerAbilitys GetAbilities()//?
    {
        if (_player == null)
            throw new ArgumentNullException(nameof(_player));

        return _player.Abilitys;
    }

    //?
    public float GetUpEnemyStat() => _levelsStorage.GetLevelSettings().UpEnemyStatForLevel;

    public int GetMinWaveSize() => _levelsStorage.GetLevelSettings().MinWaveSize;

    public int GetMaxWaveSize() => _levelsStorage.GetLevelSettings().MaxWaveSize;

    public int GetMinSquadEnemy() => _levelsStorage.GetLevelSettings().MinSquadEnemy;

    public int GetMaxSquadEnemy() => _levelsStorage.GetLevelSettings().MaxSquadEnemy;

    public int GetMinPermonentEnemy() => _levelsStorage.GetLevelSettings().MinPermonentEnemy;

    public int GetMaxPermonentEnemy() => _levelsStorage.GetLevelSettings().MaxPermonentEnemy;

    public float GetUpExceptionPercent() => _levelsStorage.GetLevelSettings().UpExeptionPercentForLevel;
}
