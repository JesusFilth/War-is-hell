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


    //private async void Actions()
    //{
    //    await Test();
    //}

    //private async Task Test()
    //{
    //    await Task.Run(() => 
    //    {
    //        Thread.Sleep(3000);
    //    }
    //    );

    //    Debug.Log("end");
    //}
}
