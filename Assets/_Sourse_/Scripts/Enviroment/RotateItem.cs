using UnityEngine;

namespace Enviroment
{
    public class RotateItem : MonoBehaviour
    {
        [SerializeField] private float _speed = 250f;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.Rotate(Vector3.up, _speed * Time.deltaTime);
        }
    }
}