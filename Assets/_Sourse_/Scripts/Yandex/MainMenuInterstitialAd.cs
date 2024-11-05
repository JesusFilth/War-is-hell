using UnityEngine;
using GamePush;

public class MainMenuInterstitialAd : MonoBehaviour
{
    private void Start()
    {
        ShowFullscreen();
    }

    public void ShowFullscreen() => GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);

    private void OnFullscreenStart()
    { 
        Debug.Log("ON FULLSCREEN START");
        FocusGame.Instance.Lock();
    } 

    private void OnFullscreenClose(bool success)
    {
        Debug.Log("ON FULLSCREEN CLOSE");
        FocusGame.Instance.Unlock();
    }
}