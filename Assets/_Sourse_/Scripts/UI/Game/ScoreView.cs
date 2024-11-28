using Reflex.Attributes;
using Sourse.Scripts.Core.GameSession;
using TMPro;
using UnityEngine;

namespace Sourse.Scripts.UI.Game
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