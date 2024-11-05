using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameModeCompanyButton : MonoBehaviour
{
    private Button _button;

    [Inject] private CurrentGameMode _currentGameMode;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _currentGameMode.ToCompanyMode();
    }
}