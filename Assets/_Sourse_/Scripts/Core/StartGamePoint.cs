using Reflex.Attributes;
using UnityEngine;

public class StartGamePoint : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;
    [Inject] private UserStorage _userStorage;
    [Inject] private GameLevelStorage _levelStorage;

    private void Start()
    {
        _stateMashine.Init(_userStorage, _levelStorage);
        _stateMashine.EnterIn<BootstrapState>();
    }
}
