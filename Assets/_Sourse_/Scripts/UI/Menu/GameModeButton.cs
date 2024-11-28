using Core.GameSession;
using Core.Storage;
using Reflex.Attributes;
using UI.Game.Buttons;
using UnityEngine;

namespace UI.Menu
{
    public class GameModeButton : ButtonView
    {
        [SerializeField] private GameMode _mode;
        [SerializeField] private GameObject _focus;

        [Inject] private CurrentGameMode _currentGameMode;
        [Inject] private UserStorage _userStorage;

        protected override void OnEnable()
        {
            base.OnEnable();
            _currentGameMode.ModeChanged += UpdateFrame;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _currentGameMode.ModeChanged -= UpdateFrame;
        }

        private void Start()
        {
            UpdateFrame(_currentGameMode.CurrentMode);
        }

        public void On()
        {
            _focus.SetActive(true);
        }

        protected override void OnClick()
        {
            if (_userStorage.IsOpenSurvivolMode() == false)
                return;

            _currentGameMode.SetGameMode(_mode);
        }

        private void UpdateFrame(GameMode mode)
        {
            _focus.SetActive(mode == _mode);
        }
    }
}
