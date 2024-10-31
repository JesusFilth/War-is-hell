using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Stats;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private PlayerAbilitys _playerAbility;

    public Character Character => _character;
    public PlayerAbilitys PlayerAbility => _playerAbility;

    public Transform Transform;

    private void Awake()
    {
        Transform = transform;
    }
}
