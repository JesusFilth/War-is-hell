using Core.Game_FSM;
using Core.GameSession;
using Reflex.Attributes;
using UnityEngine;

namespace UI.Menu
{
    public class StartGameButton : MonoBehaviour
    {
        [Inject] private GameStateMashine _stateMashine;
        [Inject] private CurrentGameMode _currentGameMode;

        public void StartGame()
        {
            _stateMashine.EnterIn<LoadGameSceneState, GameMode>(_currentGameMode.CurrentMode);
        }
    }
}