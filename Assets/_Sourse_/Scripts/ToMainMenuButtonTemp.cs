using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToMainMenuButtonTemp : MonoBehaviour
{
    private Button _button;

    [Inject] private GameStateMashine _stateMashine;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToMainMenu);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToMainMenu);
    }

    public void ToMainMenu()
    {
        _stateMashine.EnterIn<LoadMainMenuState>();
    }
}
