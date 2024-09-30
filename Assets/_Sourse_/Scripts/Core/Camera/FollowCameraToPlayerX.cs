using System;
using UnityEngine;

public class FollowCameraToPlayerX : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetY = 3f;
    [SerializeField] private float _offsetX = .0f;
    [SerializeField] private float _offsetZ = -3.0f;
    [SerializeField] private float _smoothSpeed = 6.0f;
    [Space]
    [SerializeField] private bool _isBackReturn = false;

    private Transform _transform;
    private bool _isActive = true;
    private float _lastPointBorderX;

    private void Awake()
    {
        _transform = transform;
        _lastPointBorderX = _transform.position.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_isActive == false)
            return;

        Vector3 desiredPosition = new Vector3(_target.position.x + _offsetX, _target.position.y + _offsetY, _target.position.z + _offsetZ);

        if (_isBackReturn == false)
            desiredPosition.x = Mathf.Max(desiredPosition.x, _lastPointBorderX);

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