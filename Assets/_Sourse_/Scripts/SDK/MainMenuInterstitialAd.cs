using Core;
using GamePush;
using UnityEngine;

namespace SDK
{
    public class MainMenuInterstitialAd : MonoBehaviour
    {
        private void Start()
        {
            ShowFullscreen();
        }

        public void ShowFullscreen() => GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);

        private void OnFullscreenStart()
        { 
            FocusGame.Instance.Lock();
        } 

        private void OnFullscreenClose(bool success)
        {
            FocusGame.Instance.Unlock();
        }
    }
}