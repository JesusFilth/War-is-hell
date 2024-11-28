using Core;
using Core.GameSession;
using GamePush;
using Reflex.Attributes;

namespace UI.Game.Buttons
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
