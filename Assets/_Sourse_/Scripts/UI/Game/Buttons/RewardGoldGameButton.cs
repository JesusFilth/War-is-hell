using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardGoldGameButton : MonoBehaviour
{
    [Inject] private IGameProgress _gameProgress;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnClick);

    private void OnClick()
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
