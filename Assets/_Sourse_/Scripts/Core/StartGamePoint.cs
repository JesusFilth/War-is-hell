using Reflex.Attributes;
using Sourse.Scripts.Core.Game_FSM;
using UnityEngine;

namespace Sourse.Scripts.Core
{
    public class StartGamePoint : MonoBehaviour
    {
        [Inject] private GameStateMashine _stateMashine;

        private void Start()
        {
            _stateMashine.Init();
            _stateMashine.EnterIn<BootstrapState>();
        }
    }
}