using Reflex.Core;
using UnityEngine;

public class GlobalReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private LevelsStorage _levelStorage;
    [SerializeField] private UserStorage _userStorage;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(
            _levelStorage,
            typeof(ILevelsStorage),
            typeof(IGameLevelSettings));

        containerBuilder.AddSingleton(new UserStorage());
        containerBuilder.AddSingleton(new GameStateMashine());
    }
}