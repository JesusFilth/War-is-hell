using Reflex.Attributes;
using Sourse.Scripts.Core.GameSession;
using TMPro;
using UnityEngine;

namespace Sourse.Scripts.UI.Game
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gold;

        [Inject] private IGameProgress _progress;

        private void OnEnable()
        {
            _progress.GetPlayerProgress().GoldChanged += UpdateData;
            _progress.GetPlayerProgress().UpdateGold();
        }

        private void OnDisable()
        {
            if(_progress.GetPlayerProgress() != null)
                _progress.GetPlayerProgress().GoldChanged -= UpdateData;
        }

        private void UpdateData(int gold)
        {
            _gold.text = gold.ToString();
        }
    }
}
