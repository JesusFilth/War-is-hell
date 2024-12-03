using System;
using System.Collections.Generic;
using Core;
using UI.Game.FMS.States;
using UI.Game.Views;
using UnityEngine;

namespace UI.Game.FMS
{
    public class StateMashineUI : MonoBehaviour
    {
        [SerializeField] private GameView _gameUI;
        [SerializeField] private GameView _menuUI;
        [SerializeField] private GameView _skillUI;
        [SerializeField] private GameView _levelInitUI;
        [SerializeField] private GameView _rewardLifeUI;
        [SerializeField] private GameView _gameOverUI;
        [SerializeField] private GameView _playerStatsUI;

        private GameUIState _currentState;
        private Dictionary<Type, GameUIState> _states;

        private void Awake()
        {
            Initialize();
            EnterIn<GameLevelUIState>();
        }

        public void EnterIn<TState>()
            where TState : GameUIState
        {
            if(_states.TryGetValue(typeof(TState), out GameUIState state))
            {
                _currentState?.Close();
                _currentState = state;
                _currentState.Open();
            }
        }
    
        private void Initialize()
        {
            _states = new Dictionary<Type, GameUIState>()
            {
                [typeof(GameLevelUIState)] = new GameLevelUIState(_gameUI),
                [typeof(GameMenuUIState)] = new GameMenuUIState(_menuUI),
                [typeof(LevelInitUIState)] = new LevelInitUIState(_levelInitUI),
                [typeof(SkillUIState)] = new SkillUIState(_skillUI),
                [typeof(LifeRewardUIState)] = new LifeRewardUIState(_rewardLifeUI),
                [typeof(GameOverUIState)] = new GameOverUIState(_gameOverUI),
                [typeof(PlayerStatsUIState)] = new PlayerStatsUIState(_playerStatsUI),
            };
        }
    }
}
