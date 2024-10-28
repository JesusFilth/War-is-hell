using System.Collections;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;

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
