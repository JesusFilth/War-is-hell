using Reflex.Attributes;
using Sourse.Scripts.Core.Game_FSM;
using Sourse.Scripts.Core.Storage;
using UnityEngine;

namespace Sourse.Scripts.Core
{
    public class StartGamePoint : MonoBehaviour
    {
        [Inject] private GameStateMashine _stateMashine;
        [Inject] private UserStorage _userStorage;

        private void Start()
        {
            _stateMashine.Init(_userStorage);
            _stateMashine.EnterIn<BootstrapState>();
        }
    }
}