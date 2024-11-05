using Reflex.Attributes;
using UnityEngine;
using GamePush;

public class RewardGoldGameButton : ButtonView
{
    [Inject] private IGameProgress _gameProgress;

    protected override void OnClick()
    {
        GP_Ads.ShowRewarded(null, OnRewardedReward, OnRewardedStart, OnRewardedClose);
    }

    private void OnRewardedStart()
    {
        Debug.Log("ON REWARDED: START");
        FocusGame.Instance.Lock();
    }

    private void OnRewardedReward(string value)
    {
        _gameProgress.GetPlayerProgress().AddGold(_gameProgress.GetPlayerProgress().Gold);
        gameObject.SetActive(false);
    }

    private void OnRewardedClose(bool success)
    {
        Debug.Log("ON REWARDED: CLOSE");
        FocusGame.Instance.Unlock();
    }
}
