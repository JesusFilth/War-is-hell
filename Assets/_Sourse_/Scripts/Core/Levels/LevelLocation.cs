using UnityEngine;

public class LevelLocation : MonoBehaviour
{
    [SerializeField] private Transform _playerStartPosition;

    public Transform PlayerStartPosition => _playerStartPosition;
}
