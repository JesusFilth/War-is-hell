using Reflex.Attributes;
using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 40f;
    [SerializeField] private float _distance = 1f;

    private float _currentAngle = 0f;
    private Transform _transform;

    [Inject] private IGamePlayer _player;

    private void Awake()
    {
        _transform = transform;

        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);

        _transform.position = _player.GetPlayerPosition().position;
    }

    private void Update()
    {
        if (_player == null)
            return;

        _currentAngle += _speed * Time.deltaTime;

        float radians = _currentAngle * Mathf.Deg2Rad;
        Vector3 newPosition = new Vector3(
            _player.GetPlayerPosition().position.x + Mathf.Cos(radians) * _distance,
            _player.GetPlayerPosition().position.y,
            _player.GetPlayerPosition().position.z + Mathf.Sin(radians) * _distance
        );

        _transform.position = newPosition;
        _transform.LookAt(_player.GetPlayerPosition());
    }
}