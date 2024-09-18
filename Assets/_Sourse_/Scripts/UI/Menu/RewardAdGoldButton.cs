using Reflex.Attributes;
using UnityEngine;

public class RewardAdGoldButton : MonoBehaviour
{
    [Inject] private UserStorage _userStorage;

    private int _giftCoins;

    public void Show(int coins)
    {
        _giftCoins = coins;
#if UNITY_WEBGL && !UNITY_EDITOR
         Agava.YandexGames.VideoAd.Show(OnOpenCallback,OnRevardCallback, OnCloseCallback);
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
        _userStorage.AddGold(_giftCoins);
    }
}
