using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShadowButton : ButtonView
{
    [SerializeField] private Light _light;
    [SerializeField] private GameObject _on;
    [SerializeField] private GameObject _off;

    private bool _isAcrive = true;

    protected override void OnClick()
    {
        _isAcrive = !_isAcrive;
        UpdateLight();
    }

    private void UpdateLight()
    {
        _light.shadows = _isAcrive ? LightShadows.Hard : LightShadows.None;

        _on.SetActive(!_isAcrive);
        _off.SetActive(_isAcrive);
    }
}
