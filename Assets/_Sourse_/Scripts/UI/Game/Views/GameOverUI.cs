using GameCreator.Runtime.Common;
using Reflex.Attributes;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverUI : MonoBehaviour, IGameUI
{
    private CanvasGroup _canvasGroup;

    [Inject] private UserStorage _userStorage;
    [Inject] private IGameProgress _gameProgress;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        TimeManager.Instance.SetTimeScale(0, 5);

        _userStorage.AddScore(_gameProgress.GetPlayerProgress().Score);
    }
}
