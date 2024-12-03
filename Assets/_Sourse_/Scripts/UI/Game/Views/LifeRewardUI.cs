using Core;
using Core.GameSession;
using GameCreator.Runtime.Common;
using GamePush;
using Reflex.Attributes;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game.Views
{
    public class LifeRewardUI : GameView
    {
        [SerializeField] private Button _rewardBtn;
        [SerializeField] private Button _continueBtn;

        private bool _isHasLife;

        [Inject] private StateMashineUI _gameUI;
        [Inject] private IGamePlayer _player;

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

        public override void Hide()
        {
            SetCanvasVisibility(false);
        }

        public override void Show()
        {
            if (_isHasLife)
            {
                _gameUI.EnterIn<GameOverUIState>();
                return;
            }

            SetCanvasVisibility(true);

            TimeManager.Instance.SetTimeScale(0);
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
