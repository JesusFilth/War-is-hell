using Reflex.Attributes;
using UnityEngine;

public class StartGamePoint : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;
    [Inject] private UserStorage _userStorage;
    [Inject] private IGameLevels _gameLevels;

    private void Start()
    {
        _stateMashine.Init(_userStorage, _gameLevels);
        _stateMashine.EnterIn<BootstrapState>();
    }
}