using Reflex.Attributes;
using UI.Game.FMS;
using UI.Game.FMS.States;

namespace UI.Game.Buttons
{
    public class PlayerStatsButton : ButtonView
    {
        [Inject] private StateMashineUI _mashineUI;

        protected override void OnClick()
        {
            _mashineUI.EnterIn<PlayerStatsUIState>();
        }
    }
}
