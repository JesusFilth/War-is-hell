using Reflex.Attributes;
using UnityEngine;

public class RotateToPlayerY : MonoBehaviour
{
    [Inject] private Player _player;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void Start()
    {
        Vector3 direction = _player.Transform.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }
}