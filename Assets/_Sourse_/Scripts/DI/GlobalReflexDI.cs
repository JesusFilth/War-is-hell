using Reflex.Core;
using UnityEngine;

public class GlobalReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private GameLevelStorage _levelStorage;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_levelStorage);
    }
}