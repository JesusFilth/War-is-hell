using GameCreator.Runtime.Characters;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAbilitys _ability;
    [SerializeField] private Character _character;
    [SerializeField] private bool _isDontDestroy = true;

    public Transform Transform { get; private set; }
    public PlayerProgress Progress { get; private set; } = new();
    public PlayerAbilitys Abilitys => _ability;

    private void Awake()
    {
        Transform = transform;

        if(_isDontDestroy)
            DontDestroyOnLoad(gameObject);
    }

    public void SetPosition(Vector3 position)
    {
        _character.Driver.SetPosition(position);
    }
}