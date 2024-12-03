using GameCreator.Runtime.Common;
using UnityEngine;

namespace UI.Game.Views
{
    public class GameLevelUI : GameView
    {
        public override void Hide()
        {
            SetCanvasVisibility(false);
        }

        public override void Show()
        {
            SetCanvasVisibility(true);

            Time.timeScale = 1;
            TimeManager.Instance.SetTimeScale(1);
        }
    }
}
