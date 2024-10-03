using System;
using GameCreator.Runtime.Cameras;
using UnityEngine;

public class GameLevelCamera : MonoBehaviour
{
    [SerializeField] private ShotCamera _shotCamera;

    public void On() => _shotCamera.enabled = true;

    public void Off() => _shotCamera.enabled = false;

    private void OnValidate()
    {
        if (_shotCamera == null)
            throw new ArgumentNullException(nameof(_shotCamera));
    }

    public void SetDistance(Vector3 offset)
    {
        ShotTypeFollow cameraType = _shotCamera.ShotType as ShotTypeFollow;

        if (cameraType != null)
            cameraType.Follow.Distance = offset;
        else
            throw new InvalidCastException(nameof(cameraType));
    }
}