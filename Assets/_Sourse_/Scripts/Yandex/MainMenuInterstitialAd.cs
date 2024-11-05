using UnityEngine;

public class MainMenuInterstitialAd : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("sdk");
//#if UNITY_WEBGL && !UNITY_EDITOR
//        InterstitialAd.Show(OnOpenAdCallback, OnCloseAdCallback);
//#endif
    }

    private void OnOpenAdCallback()
    {
        FocusGame.Instance.Lock();
    }

    private void OnCloseAdCallback(bool wasShown)
    {
        FocusGame.Instance.Unlock();
    }
}