using GameCreator.Runtime.Characters;
using UnityEngine;

namespace Skills.SkillEffects
{
    public class RotateAroundPlayer : MonoBehaviour
    {
        [SerializeField] private float _speed = 40f;
        [SerializeField] private float _distance = 1f;

        private float _currentAngle = 0f;
        private Transform _transform;
        private Transform _target;

        private void Awake()
        {
            _transform = transform;
            _target = GetGameObjectPlayer.Create().EditorValue.transform;
        }

        private void Update()
        {
            if (_target == null)
                return;

            _currentAngle += _speed * Time.deltaTime;

            float radians = _currentAngle * Mathf.Deg2Rad;
            Vector3 newPosition = new Vector3(
                _target.position.x + Mathf.Cos(radians) * _distance,
                _target.position.y,
                _target.position.z + Mathf.Sin(radians) * _distance
            );

            _transform.position = newPosition;
            _transform.LookAt(_target);
        }
    }
}