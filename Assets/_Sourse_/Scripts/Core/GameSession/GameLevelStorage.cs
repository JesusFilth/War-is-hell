using System;
using IJunior.TypedScenes;
using Reflex.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevelStorage : MonoBehaviour,
    IGameLevels,
    IGamePlayer,
    IGameProgress,
    IPlayerAbilities
{
    [SerializeField] private LevelLocation[] _levels;
    [SerializeField] private Player _playerPrefab;

    private Player _player;
    private LevelLocation _currentLevel;

    public void LoadGameLevel()
    {
        if(_currentLevel != null)
            Destroy(_currentLevel.gameObject);

        int randomLevelIndex = Random.Range(0, _levels.Length);
        _currentLevel = Instantiate(_levels[randomLevelIndex]);

        InitPlayer(_currentLevel.PlayerStartPosition.position);
        _player.Progress.AddLevel();
    }

    public void NextGameLevelLoad()
    {

    }

    public void InitPlayer(Vector3 position)
    {
        if(_player == null)
            _player = Instantiate(_playerPrefab);

        _player.SetPosition(position);
    }

    public void DestroyPlayer()
    {
        if(_player != null)
            Destroy(_player.gameObject);
    }

    public Transform GetPlayerPosition()
    {
        if (_player == null)
            throw new ArgumentNullException(nameof(_player));

        return _player.Transform;
    }

    public PlayerProgress GetPlayerProgress()
    {
        if (_player == null)
            throw new ArgumentNullException(nameof(_player));

        return _player.Progress;
    }

    public PlayerAbilitys GetAbilities()
    {
        if (_player == null)
            throw new ArgumentNullException(nameof(_player));

        return _player.Abilitys;
    }
}