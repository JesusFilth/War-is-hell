using GameCreator.Runtime.Characters;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private PlayerAbilitys _playerAbility;

    public Character Character => _character;
    public PlayerAbilitys PlayerAbility => _playerAbility;
}
