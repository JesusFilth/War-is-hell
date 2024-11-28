using Core.GameSession;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;

        [Inject] private IGameProgress _progress;

        private void OnEnable()
        {
            _progress.GetPlayerProgress().ScoreChanged += OnUpdateData;
        }

        private void OnDisable()
        {
            _progress.GetPlayerProgress().ScoreChanged -= OnUpdateData;
        }

        private void OnUpdateData(int score)
        {
            _score.text = score.ToString();
        }
    }
}