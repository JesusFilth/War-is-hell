using Reflex.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelLocation : MonoBehaviour
{
    private const float MinPositionX = -50;
    private const float MaxPositionX = 50;

    [SerializeField] private Transform _playerStartPosition;
    [SerializeField] private bool _isRandomX = true;

    public Transform PlayerStartPosition => _playerStartPosition;

    [Inject] private StateMashineUI _stateMashineUI;

    private void Awake()
    {
        if(_isRandomX)
            ChangeRandomPositionX();

        DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void Start()
    {
        _stateMashineUI.EnterIn<LevelInitUIState>();
    }

    private void ChangeRandomPositionX()
    {
        float x = Random.Range(MinPositionX, MaxPositionX);
        transform.position = new Vector3(x, 0, 0);
    }
}
