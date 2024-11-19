using Reflex.Attributes;
using Sourse.Scripts.UI.Game.FMS;
using Sourse.Scripts.UI.Game.FMS.States;
using UnityEngine;

namespace Sourse.Scripts.Core
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
