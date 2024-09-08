using System.Collections;
using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

public class BorderStartWave : MonoBehaviour
{
    [SerializeField] private GameObject[] _borders;

    [Inject] FollowCameraToPlayerX _camera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _camera.Off();
            BordersOn();
        }
    }

    private void BordersOn()
    {
        if (_borders == null)
            return;

        foreach (GameObject obj in _borders)
        {
            obj.SetActive(true);
        }
    }

    private void BordersOff()
    {
        if (_borders == null)
            return;

        foreach (GameObject obj in _borders)
        {
            obj.SetActive(false);
        }
    }
}
