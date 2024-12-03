using System.Collections;
using Core.GameSession;
using Core.Storage;
using Reflex.Attributes;
using TMPro;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game.Views
{
    public class LevelInitUI : GameView
    {
        [SerializeField] private Image _screen;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private float _delay = 3;

        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        [Inject] private IGameLevel _gameLevel;
        [Inject] private StateMashineUI _stateMashineUI;
        [Inject] private ILoadScreens _loadScreens;

        private void OnEnable()
        {
            _waitForSeconds = new WaitForSeconds(_delay);
        }

        private void OnDisable()
        {
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public override void Hide()
        {
            SetCanvasVisibility(false);
        }

        public override void Show()
        {
            SetCanvasVisibility(true);

            _screen.sprite = _loadScreens.GetRandomScreen();
            _level.text = _gameLevel.GetCurrentLevelNumber().ToString();

            if (_coroutine == null)
                _coroutine = StartCoroutine(Showing());
        }

        private IEnumerator Showing()
        {
            yield return _waitForSeconds;

            _stateMashineUI.EnterIn<GameLevelUIState>();
            _coroutine = null;
        }
    }
}
