using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [Inject] private StateMashineUI _stateMashineUI;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnClick);

    private void OnClick()
    {
        _stateMashineUI.EnterIn<GameMenuUIState>();
    }
}
