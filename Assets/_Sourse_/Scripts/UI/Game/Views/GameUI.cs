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
            const float AlphaHide = 1;

            _canvasGroup.alpha = AlphaHide;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }

        public void Show()
        {
            const int LayerTime = 5;
            const float TimeScale = 1;
            const float AlphaShow = 1;

            _canvasGroup.alpha = AlphaShow;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;

            Time.timeScale = 1;
            TimeManager.Instance.SetTimeScale(TimeScale, LayerTime);
        }
    }
}
