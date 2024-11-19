using Reflex.Attributes;
using Sourse.Scripts.UI.Game.FMS;
using Sourse.Scripts.UI.Game.FMS.States;

namespace Sourse.Scripts.UI.Game.Buttons
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
