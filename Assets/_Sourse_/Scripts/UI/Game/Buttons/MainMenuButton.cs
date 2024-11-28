using Core.Game_FSM;
using Core.GameSession;
using Core.Storage;
using Reflex.Attributes;

namespace UI.Game.Buttons
{
    public class MainMenuButton : ButtonView
    {
        [Inject] private GameStateMashine _stateMashine;
        [Inject] private UserStorage _userStorage;
        [Inject] private IGameProgress _progress;

        protected override void OnClick()
        {
            _userStorage.AddGold(_progress.GetPlayerProgress().Gold);
            _userStorage.AddScore(_progress.GetPlayerProgress().Score);

            _stateMashine.EnterIn<LoadMainMenuState>();
        }
    }
}
