using GameCreator.Runtime.Common;
using Reflex.Attributes;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.Core.Storage;
using Sourse.Scripts.UI.Game.FMS;
using UnityEngine;

namespace Sourse.Scripts.UI.Game.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverUI : MonoBehaviour, IGameUI
    {
        [SerializeField] private GameObject _completedCompany;

        private CanvasGroup _canvasGroup;

        [Inject] private UserStorage _userStorage;
        [Inject] private IGameProgress _gameProgress;
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
            const int LayerTime = 5;

            SetCanvasVisibility(true);

            TimeManager.Instance.SetTimeScale(0, LayerTime);

            if(_level.IsCompanyCompleted())
                _completedCompany.SetActive(true);

            _userStorage.AddScore(_gameProgress.GetPlayerProgress().Score);
        }

        private void SetCanvasVisibility(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }
    }
}
