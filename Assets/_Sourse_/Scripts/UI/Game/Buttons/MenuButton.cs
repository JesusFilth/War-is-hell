using Reflex.Attributes;

public class MenuButton : ButtonView
{
    [Inject] private StateMashineUI _stateMashineUI;

    protected override void OnClick()
    {
        _stateMashineUI.EnterIn<GameMenuUIState>();
    }
}
