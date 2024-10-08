using System;
using UnityEngine;

public class LevelsStorage : MonoBehaviour
{
    [SerializeField] private LevelLocation[] _levels;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private LevelSettings _levelSettings;

    public LevelLocation GetLevelLocation(int index)
    {
        if (index < 0 || index > _levels.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _levels[index];
    }

    public Player GetPlayerPrefab() => _playerPrefab;

    public LevelSettings GetLevelSettings() => _levelSettings;
}