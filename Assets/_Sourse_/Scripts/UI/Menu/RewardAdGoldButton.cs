using Core;
using Core.Storage;
using GamePush;
using Reflex.Attributes;
using UnityEngine;

namespace UI.Menu
{
    public class RewardAdGoldButton : MonoBehaviour
    {
        [Inject] private UserStorage _userStorage;

        public void ShowRewarded(int coin) => GP_Ads.ShowRewarded(coin.ToString(), OnRewardedReward, OnRewardedStart, OnRewardedClose);

        private void OnRewardedStart()
        {
            FocusGame.Instance.Lock();
        }

        private void OnRewardedReward(string value)
        {
            int coin = int.Parse(value);
            _userStorage.AddGold(coin);
        }

        private void OnRewardedClose(bool success)
        {
            FocusGame.Instance.Unlock();
        }
    }
}
