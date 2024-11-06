using Examples.Console;
using GamePush;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;

[System.Serializable]
public class LeaderboardFetchData
{
    public int score;
    public string name;
}

public class LederboardView : MonoBehaviour
{
    private const string LeaderboardName = "best_player";
    private const int MaxElements = 7;

    [SerializeField] private LeaderboadElement _prefab;
    [SerializeField] private Transform _conteiner;

    [SerializeField] private TMP_Text _info;

    private List<LeaderboardPlayer> _leaderboardPlayers = new();//?
    private List<LeaderboadElement> _leaderboadElements = new();

    private void OnEnable()
    {
        GP_Leaderboard.OnFetchSuccess += OnFetchSuccess;
    }

    private void OnDisable()
    {
        GP_Leaderboard.OnFetchSuccess -= OnFetchSuccess;
    }

    private void Start()
    {
        GP_Player.Sync();
        Debug.Log("start leaderboard");
        Fetch();
    }

    private void Fetch() => GP_Leaderboard.Fetch();

    // Результат получения
    private void OnFetchSuccess(string fetchTag, GP_Data data)
    {
        Debug.Log("OnFetchSuccess");
        var players = data.GetList<LeaderboardFetchData>();

        _info.text += $"count:{players.Count}\n";

        for (int i = 0; i < players.Count; i++)
        {
            LeaderboadElement temp = Instantiate(_prefab, _conteiner);

            _info.text += $"i={i} - name:{players[i].name} - score{players[i].score}\n";

            temp.Init(
                (i+1).ToString(),
                players[i].name,
                players[i].score.ToString());

            _leaderboadElements.Add(temp);
        }
    }

    private void ClearElements()
    {
        foreach (LeaderboadElement element in _leaderboadElements)
        {
            Destroy(element.gameObject);
        }
    }
}
