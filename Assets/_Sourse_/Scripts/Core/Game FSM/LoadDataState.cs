using System;
using Agava.YandexGames;
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
        Debug.Log("SDK Disable. temp");
        LoadPlayerPrefs();
        return;

#if UNITY_WEBGL && !UNITY_EDITOR
            if (PlayerAccount.IsAuthorized)
                LoadCloud();
            else
                LoadPlayerPrefs();
#else
        LoadPlayerPrefs();
#endif
    }

    private void LoadPlayerPrefs()
    {
        string json = PlayerPrefs.GetString(UserKey);
        SetLoadUserData(GetDeserialize(json));
    }

    private void LoadCloud()
    {
        PlayerAccount.GetCloudSaveData(onSuccessCallback: (json) =>
        {
            SetLoadUserData(GetDeserialize(json));
        });
    }

    private void SetLoadUserData(UserModel user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _userStorage.SetUser(user);
        _stateMashine.EnterIn<LoadMainMenuState>();
    }

    private UserModel GetDeserialize(string json)
    {
        return GetDefaultUser();//temp

        if (string.IsNullOrEmpty(json))
            return GetDefaultUser();

        UserModel userModel = JsonUtility.FromJson<UserModel>(json);

        if (userModel == null)
            return GetDefaultUser();

        return userModel;
    }

    private UserModel GetDefaultUser()
    {
        return new UserModel() { Name = "Player", Gold = 100, Score = 0 };
    }
}