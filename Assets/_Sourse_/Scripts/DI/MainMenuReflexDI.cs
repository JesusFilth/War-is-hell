using Reflex.Core;
using UI.Menu;
using UnityEngine;

namespace DI
{
    public class MainMenuReflexDI : MonoBehaviour, IInstaller
    {
        [SerializeField] private CurrentGameMode _currentGameMode;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(_currentGameMode);
        }
    }
}
