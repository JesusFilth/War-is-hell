using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class RewardGoldGameButton : ButtonView
{
    [Inject] private IGameProgress _gameProgress;

    protected override void OnClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRevardCallback, OnCloseCallback);
#else
        OnRevardCallback();
#endif
    }

    private void OnOpenCallback()
    {
        FocusGame.Instance.Lock();
    }

    private void OnCloseCallback()
    {
        FocusGame.Instance.Unlock();
    }

    private void OnRevardCallback()
    {
        _gameProgress.GetPlayerProgress().AddGold(_gameProgress.GetPlayerProgress().Gold);
        gameObject.SetActive(false);
    }
}
