using System.Collections;
using Reflex.Attributes;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.Core.Storage;
using Sourse.Scripts.UI.Game.FMS;
using Sourse.Scripts.UI.Game.FMS.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sourse.Scripts.UI.Game.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelInitUI : MonoBehaviour, IGameUI
    {
        [SerializeField] private Image _screen;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private float _delay = 3;

        private CanvasGroup _canvasGroup;
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        [Inject] private IGameLevel _gameLevel;
        [Inject] private StateMashineUI _stateMashineUI;
        [Inject] private ILoadScreens _loadScreens;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
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

        public void Hide()
        {
            SetCanvasVisibility(false);
        }

        public void Show()
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

        private void SetCanvasVisibility(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }
    }
}
