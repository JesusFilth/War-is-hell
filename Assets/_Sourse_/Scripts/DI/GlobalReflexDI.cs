using Reflex.Core;
using Sourse.Scripts.Core.Game_FSM;
using Sourse.Scripts.Core.Storage;
using UnityEngine;

namespace Sourse.Scripts.DI
{
    public class GlobalReflexDI : MonoBehaviour, IInstaller
    {
        [SerializeField] private LevelsStorage _levelStorage;
        [SerializeField] private UserStorage _userStorage;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(
                _levelStorage,
                typeof(ILevelsStorage),
                typeof(IGameLevelSettings),
                typeof(IHeroStorage),
                typeof(ILoadScreens));

            containerBuilder.AddSingleton(new UserStorage());
            containerBuilder.AddSingleton(new GameStateMashine());
        }
    }
}