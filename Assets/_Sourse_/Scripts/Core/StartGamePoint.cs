using Core.Game_FSM;
using Reflex.Attributes;
using UnityEngine;

namespace Core
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