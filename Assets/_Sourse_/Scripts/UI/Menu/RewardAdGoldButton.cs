using GamePush;
using Reflex.Attributes;
using UnityEngine;

public class RewardAdGoldButton : MonoBehaviour
{
    [Inject] private UserStorage _userStorage;

    public void ShowRewarded(int coin) => GP_Ads.ShowRewarded(coin.ToString(), OnRewardedReward, OnRewardedStart, OnRewardedClose);

    private void OnRewardedStart()
    {
        Debug.Log("ON REWARDED: START");
        FocusGame.Instance.Lock();
    }

    private void OnRewardedReward(string value)
    {
        int coin = int.Parse(value);
        _userStorage.AddGold(coin);
    }

    private void OnRewardedClose(bool success)
    {
        Debug.Log("ON REWARDED: CLOSE");
        FocusGame.Instance.Unlock();
    }
}
