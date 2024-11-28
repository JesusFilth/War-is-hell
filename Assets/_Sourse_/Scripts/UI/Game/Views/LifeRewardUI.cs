using GameCreator.Runtime.Common;
using GamePush;
using Reflex.Attributes;
using Sourse.Scripts.Core;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.UI.Game.FMS;
using Sourse.Scripts.UI.Game.FMS.States;
using UnityEngine;
using UnityEngine.UI;

namespace Sourse.Scripts.UI.Game.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LifeRewardUI : MonoBehaviour, IGameUI
    {
        [SerializeField] private Button _rewardBtn;
        [SerializeField] private Button _continueBtn;

        private CanvasGroup _canvasGroup;
        private bool _isHasLife;

        [Inject] private StateMashineUI _gameUI;
        [Inject] private IGamePlayer _player;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            Hide();
        }

        private void OnEnable()
        {
            _rewardBtn.onClick.AddListener(ShowReward);
            _continueBtn.onClick.AddListener(ToContinue);
        }

        private void OnDisable()
        {
            _rewardBtn.onClick.RemoveListener(ShowReward);
            _continueBtn.onClick.RemoveListener(ToContinue);
        }

        public void Hide()
        {
            SetCanvasVisibility(false);
        }

        public void Show()
        {
            const int LayerTime = 5;

            if (_isHasLife)
            {
                _gameUI.EnterIn<GameOverUIState>();
                return;
            }

            SetCanvasVisibility(true);

            TimeManager.Instance.SetTimeScale(0, LayerTime);
        }

        private void SetCanvasVisibility(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }

        private void ShowReward()
        {
            GP_Ads.ShowRewarded(null, OnRevardCallback, OnOpenCallback, OnCloseCallback);
        }

        private void ToContinue()
        {
            _gameUI.EnterIn<GameOverUIState>();
        }

        private void OnOpenCallback()
        {
            FocusGame.Instance.Lock();
        }

        private void OnCloseCallback(bool success)
        {
            FocusGame.Instance.Unlock();
        }

        private void OnRevardCallback(string value)
        {
            _isHasLife = true;
            _player.Resurrect();

            _gameUI.EnterIn<GameLevelUIState>();
        }
    }
}
