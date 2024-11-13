using GameCreator.Runtime.Common;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class MenuUI : MonoBehaviour, IGameUI
{
    [SerializeField] private TMP_Text _levelNumber;

    private CanvasGroup _canvasGroup;

    [Inject] private IGameLevel _level;

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

        TimeManager.Instance.SetTimeScale(1, 5);
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        _levelNumber.text = _level.GetCurrentLevelNumber().ToString();

        TimeManager.Instance.SetTimeScale(0, 5);
    }
}