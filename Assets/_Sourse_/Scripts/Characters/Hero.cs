using GameCreator.Runtime.Characters;
using Sourse.Scripts.Characters.Player;
using UnityEngine;

namespace Sourse.Scripts.Characters
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private PlayerAbilities _playerAbilities;

        public Character Character => _character;
        public PlayerAbilities PlayerAbility => _playerAbilities;
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = transform;
        }
    }
}
