using Reflex.Core;
using UnityEngine;

public class GameReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private FollowCameraToPlayerX _followCamera;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_followCamera);
    }
}