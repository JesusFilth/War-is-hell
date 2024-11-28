using Reflex.Attributes;
using UI.Game.FMS;
using UI.Game.FMS.States;

namespace UI.Game.Buttons
{
    public class ContinueGameButton : ButtonView
    {
        [Inject] private StateMashineUI _stateMashine;

        protected override void OnClick()
        {
            _stateMashine.EnterIn<GameLevelUIState>();
        }
    }
}