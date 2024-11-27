using GamePush;
using Reflex.Attributes;
using Sourse.Scripts.Core;
using Sourse.Scripts.Core.GameSession;
using UnityEngine;

namespace Sourse.Scripts.UI.Game.Buttons
{
    public class RewardGoldGameButton : ButtonView
    {
        [Inject] private IGameProgress _gameProgress;

        protected override void OnClick()
        {
            GP_Ads.ShowRewarded(null, OnRewardedReward, OnRewardedStart, OnRewardedClose);
        }

        private void OnRewardedStart()
        {
            FocusGame.Instance.Lock();
        }

        private void OnRewardedReward(string value)
        {
            _gameProgress.GetPlayerProgress().AddGold(_gameProgress.GetPlayerProgress().Gold);
            gameObject.SetActive(false);
        }

        private void OnRewardedClose(bool success)
        {
            FocusGame.Instance.Unlock();
        }
    }
}
