using System;
using Sourse.Scripts.Core.Storage;

namespace Sourse.Scripts.Core.Game_FSM
{
    public class LoadDataState : IGameState
    {
        private readonly GameStateMashine _stateMashine;
        private readonly UserStorage _userStorage;

        public LoadDataState(GameStateMashine stateMashine, UserStorage userStorage)
        {
            if (stateMashine == null)
                throw new ArgumentNullException(nameof(stateMashine));

            if (userStorage == null)
                throw new ArgumentNullException(nameof(userStorage));

            _stateMashine = stateMashine;
            _userStorage = userStorage;
        }

        public void Execute()
        {
            Load();
        }

        private void Load()
        {
            _stateMashine.EnterIn<LoadMainMenuState>();
        }
    }
}