using System;
using Agava.YandexGames;
using UnityEngine;

public class UserStorage
{
    private const string UserKey = "User";
    private const string LeaderboardName = "Leaderboard";

    private UserModel _user;

    public void SetUser(UserModel user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _user = user;
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(_user);
        PlayerPrefs.SetString(UserKey, json);
        PlayerPrefs.Save();

#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(json);
#endif
    }
}