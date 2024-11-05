using System;
using UnityEngine;

public class BootstrapState : IGameState
{
    private readonly GameStateMashine _stateMashine;

    public BootstrapState(GameStateMashine stateMashine)
    {
        if (stateMashine == null)
            throw new ArgumentNullException(nameof(stateMashine));

        _stateMashine = stateMashine;
    }

    public void Execute()
    {
        Debug.Log("sdk");
        //#if UNITY_WEBGL && !UNITY_EDITOR
        //        YandexGamesSdk.CallbackLogging = true;
        //        CoroutineRunner.Instance.Run(Initialize());
        //#else
        //        _stateMashine.EnterIn<LoadDataState>();
        //#endif
        _stateMashine.EnterIn<LoadDataState>();
    }

    //private IEnumerator Initialize()
    //{
    //    yield return YandexGamesSdk.Initialize(OnInitialized);
    //}

//    private void OnInitialized()
//    {
//#if UNITY_WEBGL && !UNITY_EDITOR
//        YandexGamesSdk.GameReady();
//#endif
//        _stateMashine.EnterIn<LoadDataState>();
//    }
}