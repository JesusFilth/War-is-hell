using Reflex.Attributes;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;
    [Inject] private CurrentGameMode _currentGameMode;

    public void StartGame()
    {
        Debug.Log("Survival mode: " + _currentGameMode.CurrentMode);
        _stateMashine.EnterIn<LoadGameSceneState, GameMode>(_currentGameMode.CurrentMode);
    }
}