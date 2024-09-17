using System;
using IJunior.TypedScenes;
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

    public void LoadGameLevel()
    {
        int randomLevelIndex = Random.Range(0, _levels.Length);
        Game.Load(_levels[randomLevelIndex]);
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