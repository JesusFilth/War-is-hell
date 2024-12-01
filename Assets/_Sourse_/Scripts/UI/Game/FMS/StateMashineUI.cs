using System;
using System.Collections.Generic;
using Core;
using UI.Game.FMS.States;
using UnityEngine;

namespace UI.Game.FMS
{
    public class StateMashineUI : MonoBehaviour
    {
        [SerializeField][SerializeInterface(typeof(IGameUI))] private GameObject _gameUI;
        [SerializeField][SerializeInterface(typeof(IGameUI))] private GameObject _menuUI;
        [SerializeField][SerializeInterface(typeof(IGameUI))] private GameObject _skillUI;
        [SerializeField][SerializeInterface(typeof(IGameUI))] private GameObject _levelInitUI;
        [SerializeField][SerializeInterface(typeof(IGameUI))] private GameObject _rewardLifeUI;
        [SerializeField][SerializeInterface(typeof(IGameUI))] private GameObject _gameOverUI;
        [SerializeField][SerializeInterface(typeof(IGameUI))] private GameObject _playerStatsUI;

        private GameUIState _currentState;
        private Dictionary<Type, GameUIState> _states;

        private void OnValidate()
        {
            if (_gameUI == null)
                throw new ArgumentNullException(nameof(_gameUI));

            if (_skillUI == null)
                throw new ArgumentNullException(nameof(_skillUI));

            if (_levelInitUI == null)
                throw new ArgumentNullException(nameof(_levelInitUI));
        }

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
                [typeof(GameLevelUIState)] = new GameLevelUIState(_gameUI.GetComponent<IGameUI>()),
                [typeof(GameMenuUIState)] = new GameMenuUIState(_menuUI.GetComponent<IGameUI>()),
                [typeof(LevelInitUIState)] = new LevelInitUIState(_levelInitUI.GetComponent<IGameUI>()),
                [typeof(SkillUIState)] = new SkillUIState(_skillUI.GetComponent<IGameUI>()),
                [typeof(LifeRewardUIState)] = new LifeRewardUIState(_rewardLifeUI.GetComponent<IGameUI>()),
                [typeof(GameOverUIState)] = new GameOverUIState(_gameOverUI.GetComponent<IGameUI>()),
                [typeof(PlayerStatsUIState)] = new PlayerStatsUIState(_playerStatsUI.GetComponent<IGameUI>()),
            };
        }
    }
}
