using System;
using UnityEngine;

public class FollowCameraToPlayerX : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetY = 2.0f;
    [SerializeField] private float _offsetX = .0f;
    [SerializeField] private float _smoothSpeed = 0.125f;

    private Transform _transform;
    private bool _isActive = true;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnValidate()
    {
        if (_target == null)
            throw new ArgumentNullException(nameof(_target));
    }

    private void Update()
    {
        if (_isActive == false)
            return;

        Vector3 desiredPosition = new Vector3(_target.position.x + _offsetX, _target.position.y + _offsetY, _transform.position.z);

        _transform.position = Vector3.Lerp(_transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
    }

    public void On() => _isActive = true;

    public void Off() =>_isActive = false;
}