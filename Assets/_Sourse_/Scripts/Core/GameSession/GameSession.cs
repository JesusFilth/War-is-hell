using System;
using Core.Storage;
using Enviroment.Levels;
using Reflex.Attributes;
using Skills;
using UI.Game;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;

namespace Core.GameSession
{
    public class GameSession : MonoBehaviour,
        IGameLevel
    {
        [SerializeField] private InputView _inputView;

        private LevelLocation _currentLevel;
        private GameMode _mode;
        private int _currentNumberLevel = 1;
        private IGamePlayer _player;
        private bool _isCompanyCompleted = false;

        [Inject] private ILevelsStorage _levelsStorage;
        [Inject] private UserStorage _usersStorage;
        [Inject] private StateMashineUI _stateMashineUI;

        public void StartGame(IGamePlayer player, GameMode mode)
        {
            _player = player;
            _mode = mode;

            _currentLevel = Instantiate(_levelsStorage.GetLevelLocation(_currentNumberLevel - 1));
            _player.SetPosition(_currentLevel.PlayerStartPosition.position);
        }

        public void LoadNextLevel(Skill skill = null)
        {
            if (_mode == GameMode.Company && _levelsStorage.GetLastLevelNumber() == _currentNumberLevel)
            {
                _isCompanyCompleted = true;
                _usersStorage.OpenSurvivalMode();
                _stateMashineUI.EnterIn<GameOverUIState>();
                return;
            }

            _currentNumberLevel++;

            if (_currentLevel != null)
                Destroy(_currentLevel.gameObject);

            _currentLevel = GetLevelLocation();
            _player.SetPosition(_currentLevel.PlayerStartPosition.position);
            _currentLevel.SetPriseSkill(skill);

            _inputView.Off();
        }

        public bool IsCompanyCompleted() => _isCompanyCompleted;

        public int GetCurrentLevelNumber() => _currentNumberLevel;

        public GameMode GetCurrentMode() => _mode;

        private LevelLocation GetLevelLocation()
        {
            switch (_mode)
            {
                case GameMode.Company:
                    return Instantiate(_levelsStorage.GetLevelLocation(_currentNumberLevel - 1));

                case GameMode.Survival:
                    return Instantiate(_levelsStorage.GetRandomLevelLocation());
            }

            throw new InvalidOperationException(nameof(_mode));
        }
    }
}
