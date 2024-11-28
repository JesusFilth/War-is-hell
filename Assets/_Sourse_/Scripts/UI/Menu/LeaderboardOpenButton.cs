using GamePush;
using UI.Game.Buttons;

namespace UI.Menu
{
    public class LeaderboardOpenButton : ButtonView
    {
        protected override void OnClick()
        {
            GP_Leaderboard.Open();
        }
    }
}