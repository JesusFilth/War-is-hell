using GameCreator.Runtime.Common;
using Sourse.Scripts.UI.Game.FMS;
using UnityEngine;

namespace Sourse.Scripts.UI.Game.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameUI : MonoBehaviour, IGameUI
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            Hide();
        }

        public void Hide()
        {
            SetCanvasVisibility(false);
        }

        public void Show()
        {
            const int LayerTime = 5;

            SetCanvasVisibility(true);

            Time.timeScale = 1;
            TimeManager.Instance.SetTimeScale(1, LayerTime);
        }

        private void SetCanvasVisibility(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }
    }
}
