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
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        public void Show()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            TimeManager.Instance.SetTimeScale(0, 5);

            if(_level.IsCompanyCompleted())
                _completedCompany.SetActive(true);

            _userStorage.AddScore(_gameProgress.GetPlayerProgress().Score);
        }
    }
}
