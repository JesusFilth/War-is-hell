using Core;
using Core.Game_FSM;
using GameCreator.Runtime.Variables;
using GamePush;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class RewardBonusStartGameButton : MonoBehaviour
    {
        private const string ValueBonusName = "bonus";

        [SerializeField] private GlobalNameVariables _bonus;
        [SerializeField] private float _bonusHP = 50;

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
            GP_Ads.ShowRewarded(null, OnRevardCallback, OnOpenCallback, OnCloseCallback);
        }

        private void OnOpenCallback()
        {
            FocusGame.Instance.Lock();
        }

        private void OnCloseCallback(bool success)
        {
            FocusGame.Instance.Unlock();
        }

        private void OnRevardCallback(string value)
        {
            _bonus.Set(ValueBonusName, _bonusHP);
            _stateMashine.EnterIn<LoadGameSceneState>();
        }
    }
}