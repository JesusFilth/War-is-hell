using Reflex.Attributes;
using UI.Game.FMS;
using UI.Game.FMS.States;

namespace UI.Game.Buttons
{
    public class MenuButton : ButtonView
    {
        [Inject] private StateMashineUI _stateMashineUI;

        protected override void OnClick()
        {
            _stateMashineUI.EnterIn<GameMenuUIState>();
        }
    }
}
