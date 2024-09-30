using System;
using UnityEngine;

public class FollowCameraToPlayerX : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetY = 2.2f;
    [SerializeField] private float _offsetX = .0f;
    [SerializeField] private float _offsetZ = 10.0f;
    [SerializeField] private float _smoothSpeed = 0.125f;

    private Transform _transform;
    private bool _isActive = true;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (_isActive == false)
            return;

        Vector3 desiredPosition = new Vector3(_target.position.x + _offsetX, _target.position.y + _offsetY, _target.position.z+_offsetZ);

        _transform.position = Vector3.Lerp(_transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        if(target == null)
            throw new ArgumentNullException(nameof(target));

        _target = target;
    }

    public void On() => _isActive = true;

    public void Off() =>_isActive = false;
}