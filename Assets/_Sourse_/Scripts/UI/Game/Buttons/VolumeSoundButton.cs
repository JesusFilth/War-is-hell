using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VolumeSoundButton : ButtonView
{
    [SerializeField] private GameObject _on;
    [SerializeField] private GameObject _off;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (BackgroundSound.Instance.IsPlaying)
        {
            _off.SetActive(true);
            _on.SetActive(false);
        }
        else
        {
            _off.SetActive(false);
            _on.SetActive(true);
        }
    }

    protected override void OnClick()
    {
        if (BackgroundSound.Instance.IsPlaying)
            Off();
        else
            On();
    }

    private void On()
    {
        _off.SetActive(true);
        _on.SetActive(false);
        BackgroundSound.Instance.OnVolume();
    }

    private void Off()
    {
        _off.SetActive(false);
        _on.SetActive(true);
        BackgroundSound.Instance.OffVolume();
    }
}
