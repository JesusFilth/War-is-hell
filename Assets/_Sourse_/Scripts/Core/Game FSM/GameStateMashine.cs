using System;
using System.Collections.Generic;

public class GameStateMashine
{
    private Dictionary<Type, IGameState> _states;
    private IGameState _currentState;

    public void Init(UserStorage userStorage, GameLevelStorage gameLevelStorage)
    {
        _states = new Dictionary<Type, IGameState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this),
            [typeof(LoadDataState)] = new LoadDataState(this, userStorage),
            [typeof(LoadMainMenuState)] = new LoadMainMenuState(gameLevelStorage),
            [typeof(LoadGameSceneState)] = new LoadGameSceneState(gameLevelStorage),
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
}
