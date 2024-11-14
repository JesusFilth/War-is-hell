using Reflex.Attributes;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenSurvivolModeButton : MonoBehaviour
{
    [SerializeField] private float _messageDelay = 2;
    [SerializeField] private TMP_Text _message;

    private Button _button;
    private Coroutine _showing;
    private WaitForSeconds _showingTime;

    [Inject] private UserStorage _userStorage;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _showingTime = new WaitForSeconds(_messageDelay);

        Initialize();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);

        if (_showing != null)
        {
            StopCoroutine(_showing);
            _showing = null;
        }
    }

    private IEnumerator Showing()
    {
        _message.gameObject.SetActive(true);

        yield return _showingTime;

        _message.gameObject.SetActive(false);
        _showing = null;
    }

    private void OnClick()
    {
        if (_showing == null)
            _showing = StartCoroutine(Showing());
    }

    private void Initialize()
    {
        if(_userStorage.IsOpenSurvivolMode() == false)
        {
            _button.interactable = false;
        }
    }
}
