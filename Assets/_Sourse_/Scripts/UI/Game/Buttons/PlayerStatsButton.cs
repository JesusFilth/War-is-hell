using Reflex.Attributes;
using Sourse.Scripts.UI.Game.FMS;
using Sourse.Scripts.UI.Game.FMS.States;

namespace Sourse.Scripts.UI.Game.Buttons
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
