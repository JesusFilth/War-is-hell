using Core.GameSession;
using Core.Storage;
using GameCreator.Runtime.Common;
using Reflex.Attributes;
using UnityEngine;

namespace UI.Game.Views
{
    public class GameOverUI : GameView
    {
        [SerializeField] private GameObject _completedCompany;

        [Inject] private UserStorage _userStorage;
        [Inject] private IGameProgress _gameProgress;
        [Inject] private IGameLevel _level;

        public override void Hide()
        {
            SetCanvasVisibility(false);
        }

        public override void Show()
        {
            SetCanvasVisibility(true);

            TimeManager.Instance.SetTimeScale(0);

            if(_level.IsCompanyCompleted())
                _completedCompany.SetActive(true);

            _userStorage.AddScore(_gameProgress.GetPlayerProgress().Score);
        }
    }
}
