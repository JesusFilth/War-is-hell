using System.Collections.Generic;
using GamePush;
using UnityEngine;

namespace SDK
{
    public class LederboardView : MonoBehaviour
    {
        private const string Score = "score";
        private const string AnanimusName = "Ananimus";
        private const int MaxElements = 5;

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

        private void Fetch() => GP_Leaderboard.Fetch("", Score, Order.DESC,MaxElements);

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
    }
}
