using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

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
