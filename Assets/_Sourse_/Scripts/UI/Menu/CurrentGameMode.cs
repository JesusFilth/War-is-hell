using Reflex.Attributes;
using System;
using TMPro;
using UnityEngine;

public class CurrentGameMode : MonoBehaviour
{
    [Inject] private UserStorage _userStorage;

    public GameMode CurrentMode { get; private set; } = GameMode.Company;

    public event Action<GameMode> ModeChanged;

    private void Awake()
    {
        Initialize();
    }

    public void SetGameMode(GameMode gameMode)
    {
        CurrentMode = gameMode;
        ModeChanged?.Invoke(CurrentMode);
    }

    private void Initialize()
    {
        if(_userStorage.IsOpenSurvivolMode())
            CurrentMode = GameMode.Survival;
    }
}