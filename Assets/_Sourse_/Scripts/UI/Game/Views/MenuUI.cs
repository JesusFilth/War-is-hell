using GameCreator.Runtime.Common;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class MenuUI : MonoBehaviour, IGameUI
{
    private CanvasGroup _canvasGroup;

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

        TimeManager.Instance.SetTimeScale(0, 5);
    }
}