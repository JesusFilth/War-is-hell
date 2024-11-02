using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShadowButton : MonoBehaviour
{
    private const string On = "вкл";
    private const string Off = "выкл";

    [SerializeField] private Light _light;
    [SerializeField] private TMP_Text _text;

    private Button _button;
    private bool _isAcrive = true;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Click);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }

    private void Click()
    {
        _isAcrive = !_isAcrive;
        UpdateLight();
    }

    private void UpdateLight()
    {
        _light.shadows = _isAcrive ? LightShadows.Hard : LightShadows.None;
        _text.text = _isAcrive ? Off : On;
    }
}
