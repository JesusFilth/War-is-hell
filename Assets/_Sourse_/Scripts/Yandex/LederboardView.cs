using GamePush;
using System.Collections.Generic;
using UnityEngine;

public class LederboardView : MonoBehaviour
{
    private const string AnanimusName = "Ananimus";
    private const string LeaderboardName = "best_player";
    private const int MaxElements = 7;

    [SerializeField] private LeaderboadElement _prefab;
    [SerializeField] private Transform _conteiner;

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
        Fetch();
    }

    private void Fetch() => GP_Leaderboard.Fetch();

    private void OnFetchSuccess(string fetchTag, GP_Data data)
    {
        var players = data.GetList<LeaderboardFetchData>();

        for (int i = 0; i < players.Count; i++)
        {
            LeaderboadElement temp = Instantiate(_prefab, _conteiner);

            if (string.IsNullOrEmpty(players[i].name))
                players[i].name = AnanimusName;

            temp.Init(
                (i+1).ToString(),
                players[i].name,
                players[i].score.ToString(),
                players[i].avatar);

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
