using Reflex.Attributes;
using UnityEngine;

public class MovementTrap : MonoBehaviour
{
    private const float AngleX = 1f;

    [SerializeField] private float _speed = 10;

    private Transform _transform;
    private Vector3 _direction;

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
        _direction.x = direction.x > 0 ? AngleX : -AngleX;
    }

    private void Update()
    {
        _transform.position += _direction * _speed * Time.deltaTime;
    }
}