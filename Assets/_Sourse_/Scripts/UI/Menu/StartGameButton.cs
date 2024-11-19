using Reflex.Attributes;
using Sourse.Scripts.Core.Game_FSM;
using Sourse.Scripts.Core.GameSession;
using UnityEngine;

namespace Sourse.Scripts.UI.Menu
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