using Reflex.Core;
using UnityEngine;

public class MainMenuReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private CurrentGameMode _currentGameMode;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_currentGameMode);
    }
}
