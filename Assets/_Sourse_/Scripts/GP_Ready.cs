using GamePush;
using UnityEngine;

public class GP_Ready : MonoBehaviour
{
    private async void Start()
    {
        await GP_Init.Ready;
    }

    private void OnEnable()
    {
        GP_Ads.OnAdsStart += OnAdsStart;
        GP_Ads.OnAdsClose += OnAdsClose;
    }

    private void OnDisable()
    {
        GP_Ads.OnAdsStart -= OnAdsStart;
        GP_Ads.OnAdsClose -= OnAdsClose;
    }

    private void OnAdsStart()
    {
        FocusGame.Instance.Lock();
    }
    private void OnAdsClose(bool success)
    {
        FocusGame.Instance.Unlock();
    }
}