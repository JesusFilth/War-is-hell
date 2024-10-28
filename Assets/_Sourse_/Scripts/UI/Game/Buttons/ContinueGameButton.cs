using Reflex.Attributes;

public class ContinueGameButton : ButtonView
{
    [Inject] private StateMashineUI _stateMashine;

    protected override void OnClick()
    {
        _stateMashine.EnterIn<GameLevelUIState>();
    }
}