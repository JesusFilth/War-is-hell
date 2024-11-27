using System;

namespace Sourse.Scripts.Core.Game_FSM
{
    public class LoadDataState : IGameState
    {
        private readonly GameStateMashine _stateMashine;

        public LoadDataState(GameStateMashine stateMashine)
        {
            if (stateMashine == null)
                throw new ArgumentNullException(nameof(stateMashine));

            _stateMashine = stateMashine;
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