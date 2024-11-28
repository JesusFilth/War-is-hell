using System;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerProgress
    {
        public int Score { get; private set; } = 0;
        public int Gold { get; private set; }

        public event Action<int> GoldChanged;
        public event Action<int> ScoreChanged;

        public void UpdateGold() => GoldChanged?.Invoke(Gold);
        public void UpdateScore() => ScoreChanged?.Invoke(Score);

        public void AddGold(int gold)
        {
            Gold = Mathf.Clamp(Gold += gold, 0, int.MaxValue);
            GoldChanged?.Invoke(Gold);
        }

        public void AddScore(int score)
        {
            Score = Mathf.Clamp(Score + score, 0, int.MaxValue);
            ScoreChanged?.Invoke(Score);
        }
    }
}