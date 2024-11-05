using System;
using UnityEngine;
using GamePush;

public class BootstrapState : IGameState
{
    private readonly GameStateMashine _stateMashine;

    public BootstrapState(GameStateMashine stateMashine)
    {
        if (stateMashine == null)
            throw new ArgumentNullException(nameof(stateMashine));

        _stateMashine = stateMashine;
    }

    public async void Execute()
    {
        await GP_Init.Ready;
        OnPluginReady();
        Debug.Log("sdk-gp");
        //#if UNITY_WEBGL && !UNITY_EDITOR
        //        YandexGamesSdk.CallbackLogging = true;
        //        CoroutineRunner.Instance.Run(Initialize());
        //#else
        //        _stateMashine.EnterIn<LoadDataState>();
        //#endif
        //_stateMashine.EnterIn<LoadDataState>();
    }

    private void OnPluginReady()
    {
        Debug.Log("Plugin ready");
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