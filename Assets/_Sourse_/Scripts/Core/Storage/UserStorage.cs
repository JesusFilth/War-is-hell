using Agava.YandexGames;
using System;
using System.Linq;
using UnityEngine;

public class UserStorage
{
    private const string UserKey = "User";
    private const string LeaderboardName = "Leaderboard";

    private UserModel _user;

    public event Action<int> GoldChanged;
    public int UserGold => _user.Gold;

    public void SetUser(UserModel user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _user = user;
    }

    public bool HasHero(string id)
    {
        string hero = _user.Heroes.Where(hero => hero == id).FirstOrDefault();

        if(string.IsNullOrEmpty(hero))
            return false;

        return true;
    }

    public void AddGold(int value)
    {
        _user.Gold += value;
        GoldChanged?.Invoke(_user.Gold);
        Save();
    }

    public void AddHero(string id)
    {
        Array.Resize(ref _user.Heroes, _user.Heroes.Length+1);
        _user.Heroes[_user.Heroes.Length - 1] = id;
    }

    public void AddScore(int score)
    {
        if(_user.Score < score)
            _user.Score = score;

        Save();
        UpdatePlayerScore();
    }

    public void UpdateGold()
    {
        GoldChanged.Invoke(_user.Gold);
    }

    private void UpdatePlayerScore()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
   if (PlayerAccount.IsAuthorized == false)
            return;

        int score = _user.Score;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null || result.score < score)
                Leaderboard.SetScore(LeaderboardName, score);
        });
#endif
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