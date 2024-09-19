using GameCreator.Runtime.Variables;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardBonusStartGameButton : MonoBehaviour
{
    private const float BonusHP = 50;
    private const string ValueBonusName = "bonus";

    [SerializeField] private GlobalNameVariables _bonus;

    private Button _button;

    [Inject] private GameStateMashine _stateMashine;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
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
        _bonus.Set(ValueBonusName,  BonusHP);
        _stateMashine.EnterIn<LoadGameSceneState>();
    }
}