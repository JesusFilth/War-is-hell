using Core.GameSession;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gold;

        [Inject] private IGameProgress _progress;

        private void OnEnable()
        {
            _progress.GetPlayerProgress().GoldChanged += OnUpdateData;
        }

        private void OnDisable()
        {
            _progress.GetPlayerProgress().GoldChanged -= OnUpdateData;
        }

        private void OnUpdateData(int gold)
        {
            _gold.text = gold.ToString();
        }
    }
}
