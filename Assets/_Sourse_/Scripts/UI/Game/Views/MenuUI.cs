using GameCreator.Runtime.Common;
using Reflex.Attributes;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.UI.Game.FMS;
using TMPro;
using UnityEngine;

namespace Sourse.Scripts.UI.Game.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class MenuUI : MonoBehaviour, IGameUI
    {
        [SerializeField] private TMP_Text _levelNumber;

        private CanvasGroup _canvasGroup;

        [Inject] private IGameLevel _level;

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
            SetCanvasVisibility(true);

            _levelNumber.text = _level.GetCurrentLevelNumber().ToString();

            TimeManager.Instance.SetTimeScale(0, 5);
        }

        private void SetCanvasVisibility(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }
    }
}