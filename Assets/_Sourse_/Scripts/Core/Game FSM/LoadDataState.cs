using System;
using System.Net;
using UnityEngine;

public class LoadDataState : IGameState
{
    private const string UserKey = "User";

    private readonly GameStateMashine _stateMashine;
    private readonly UserStorage _userStorage;

    public LoadDataState(GameStateMashine stateMashine, UserStorage userStorage)
    {
        if (stateMashine == null)
            throw new ArgumentNullException(nameof(stateMashine));

        if (userStorage == null)
            throw new ArgumentNullException(nameof(userStorage));

        _stateMashine = stateMashine;
        _userStorage = userStorage;
    }

    public void Execute()
    {
        Load();
    }

    private void Load()
    {
        //Debug.Log("default heroes");//for test on editor
        //PlayerPrefs.SetString(UserKey, "0-true;1-false;2-false;");

        _stateMashine.EnterIn<LoadMainMenuState>();
    }
}