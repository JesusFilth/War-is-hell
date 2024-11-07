using GamePush;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class LeaderboardOpenButton : ButtonView
{
    protected override void OnClick()
    {
        GP_Leaderboard.Open();
    }
}