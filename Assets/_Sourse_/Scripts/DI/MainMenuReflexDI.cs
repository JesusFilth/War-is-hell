using Reflex.Core;
using Sourse.Scripts.UI.Menu;
using UnityEngine;

namespace Sourse.Scripts.DI
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
