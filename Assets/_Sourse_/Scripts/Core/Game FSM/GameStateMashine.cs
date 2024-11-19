using System;
using System.Collections.Generic;
using Sourse.Scripts.Core.Storage;

namespace Sourse.Scripts.Core.Game_FSM
{
    public class GameStateMashine
    {
        private Dictionary<Type, IGameState> _states;
        private IGameState _currentState;

        public void Init(UserStorage userStorage)
        {
            _states = new Dictionary<Type, IGameState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(LoadDataState)] = new LoadDataState(this, userStorage),
                [typeof(LoadMainMenuState)] = new LoadMainMenuState(),
                [typeof(LoadGameSceneState)] = new LoadGameSceneState(),
            };
        }

        public void EnterIn<TState>()
            where TState : IGameState
        {
            if (_states.TryGetValue(typeof(TState), out IGameState state))
            {
                _currentState = state;
                _currentState.Execute();
            }
        }

        public void EnterIn<TState, TParam>(TParam param)
            where TState : IGameState<TParam>
        {
            if(_states.TryGetValue(typeof(TState), out IGameState state))
            {
                _currentState = state;
                ((IGameState<TParam>)_currentState).SetParam(param);
                _currentState.Execute();
            }
        }
    }
}
