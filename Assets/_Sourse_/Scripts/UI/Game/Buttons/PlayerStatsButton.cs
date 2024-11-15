using Reflex.Attributes;

public class PlayerStatsButton : ButtonView
{
    [Inject] private StateMashineUI _mashineUI;

    protected override void OnClick()
    {
        _mashineUI.EnterIn<PlayerStatsUIState>();
    }
}
