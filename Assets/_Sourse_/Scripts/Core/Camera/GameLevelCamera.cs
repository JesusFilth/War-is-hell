using System;
using GameCreator.Runtime.Cameras;
using UnityEngine;

namespace Core.Camera
{
    public class GameLevelCamera : MonoBehaviour
    {
        [SerializeField] private ShotCamera _shotCamera;
        [SerializeField] private MainCamera _mainCamera;

        public void On()
        {
            _mainCamera.UnLock();
        }

        public void Off()
        {
            _mainCamera.Lock();
        }

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
}