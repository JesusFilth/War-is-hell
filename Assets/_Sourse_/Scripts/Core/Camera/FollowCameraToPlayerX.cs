using System;
using System.Collections;
using UnityEngine;

public class FollowCameraToPlayerX : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _border;
    [SerializeField] private Vector3 _offset = new Vector3(.0f, 3f, -3.0f);
    [SerializeField] private float _smoothSpeed = 6.0f;
    [Space]
    [SerializeField] private bool _isBackReturn = false;

    private Transform _transform;
    private bool _isActive = true;
    private float _lastPointBorderX;

    private void Awake()
    {
        if(_transform == null)
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

        Vector3 desiredPosition = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, _target.position.z + _offset.z);

        if (_isBackReturn == false)
            desiredPosition.x = Mathf.Max(desiredPosition.x, _lastPointBorderX);

        _transform.position = Vector3.Lerp(_transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        if(target == null)
            throw new ArgumentNullException(nameof(target));

        if (_transform == null)
            _transform = transform;

        _transform.position = target.position;
        _target = target;

        StartCoroutine(OnBorders());
    }

    public void SetPosition(Vector3 offset)
    {
        _offset = offset;
    }

    public void On() => _isActive = true;

    public void Off() =>_isActive = false;

    private IEnumerator OnBorders()
    {
        const float Delay = 1.0f;

        yield return new WaitForSeconds(Delay);
        _border.SetActive(true);
    }
}