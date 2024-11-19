using GamePush;
using Sourse.Scripts.UI.Game.Buttons;

namespace Sourse.Scripts.UI.Menu
{
    public class LeaderboardOpenButton : ButtonView
    {
        protected override void OnClick()
        {
            GP_Leaderboard.Open();
        }
    }
}