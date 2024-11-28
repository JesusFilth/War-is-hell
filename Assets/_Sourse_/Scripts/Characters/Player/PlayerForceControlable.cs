using GameCreator.Runtime.Characters;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace Characters.Player
{
    [RequireComponent(typeof(Character))]
    public class PlayerForceControlable : MonoBehaviour
    {
        [SerializeField] private Actions _actions;

        private Character _character;
        bool _isMoving = false;

        private void Awake()
        {
            _character = GetComponent<Character>();

            if(_character.IsPlayer == false)
                enabled = false;
        }

        private void Update()
        {
            if(_character.Kernel.IsInputActive())
                _actions?.Invoke();
        }
    }
}
