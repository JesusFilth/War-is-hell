using UnityEngine;
using Random = UnityEngine.Random;

public class LevelLocation : MonoBehaviour
{
    private const float MinPositionX = -50;
    private const float MaxPositionX = 50;

    [SerializeField] private Transform _playerStartPosition;
    [SerializeField] private bool _isRandomX = true;

    public Transform PlayerStartPosition => _playerStartPosition;

    private void Awake()
    {
        if(_isRandomX)
            ChangeRandomPositionX();
    }

    private void ChangeRandomPositionX()
    {
        float x = Random.Range(MinPositionX, MaxPositionX);
        transform.position = new Vector3(x, 0, 0);
    }
}
