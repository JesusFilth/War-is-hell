using System;
using GamePush;

namespace Core.Game_FSM
{
    public class BootstrapState : IGameState
    {
        private readonly GameStateMashine _stateMashine;

        public BootstrapState(GameStateMashine stateMashine)
        {
            if (stateMashine == null)
                throw new ArgumentNullException(nameof(stateMashine));

            _stateMashine = stateMashine;
        }

        public async void Execute()
        {
            await GP_Init.Ready;
            OnPluginReady();
        }

        private void OnPluginReady()
        {
            _stateMashine.EnterIn<LoadDataState>();
        }
    }
}