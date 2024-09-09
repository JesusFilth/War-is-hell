using Reflex.Attributes;
using UnityEngine;

public class RotateBarrel : MonoBehaviour
{
    private const float AngleY = 1f;

    [SerializeField] private float _speed = 50f;

    private Vector3 _direction;
    private Transform _transform;

    [Inject] private Player _player;

    private void Awake()
    {
        _transform = transform;

        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void Start()
    {
        Vector3 direction = _player.Transform.position - _transform.position;
        _direction.y = direction.x > 0 ? AngleY : -AngleY;
    }

    private void Update()
    {
        _transform.Rotate(_direction * Time.deltaTime * _speed);
    }
}