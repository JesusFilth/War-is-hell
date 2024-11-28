using Reflex.Attributes;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;

namespace Core
{
    public class GameOver : MonoBehaviour
    {
        [Inject] private StateMashineUI _uI;

        public void OpenWindow()
        {
            _uI.EnterIn<LifeRewardUIState>();
        }
    }
}
