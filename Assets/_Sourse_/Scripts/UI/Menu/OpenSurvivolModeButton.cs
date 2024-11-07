using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenSurvivolModeButton : MonoBehaviour
{
    private Button _button;

    [Inject] private UserStorage _userStorage;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Initialize()
    {
        if(_userStorage.IsOpenSurvivolMode() == false)
        {
            _button.interactable = false;
        }
    }
}
