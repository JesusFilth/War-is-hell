using UnityEngine;

public class CameraBorders : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private bool _isFollow = true;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_isFollow == false)
            return;

        _transform.position = new Vector3(_target.position.x,_target.position.y,_target.position.z);
    }

    public void On() => _isFollow = true;
    public void Off() => _isFollow = false;
}
