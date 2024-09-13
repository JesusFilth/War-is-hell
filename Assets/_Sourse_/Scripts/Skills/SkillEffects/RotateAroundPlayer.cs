using Reflex.Attributes;
using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 40f;
    [SerializeField] private float _distance = 1f;

    private float _currentAngle = 0f;
    private Transform _transform;

    [Inject] private LevelStorage _levalStorage;

    private void Awake()
    {
        _transform = transform;

        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);

        _transform.position = _levalStorage.Player.Transform.position;
    }

    private void Update()
    {
        if (_levalStorage == null)
            return;

        _currentAngle += _speed * Time.deltaTime;

        float radians = _currentAngle * Mathf.Deg2Rad;
        Vector3 newPosition = new Vector3(
            _levalStorage.Player.Transform.position.x + Mathf.Cos(radians) * _distance,
            _levalStorage.Player.Transform.position.y,
            _levalStorage.Player.Transform.position.z + Mathf.Sin(radians) * _distance
        );

        _transform.position = newPosition;
        _transform.LookAt(_levalStorage.Player.Transform);
    }
}