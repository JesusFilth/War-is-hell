using Reflex.Core;
using UnityEngine;

public class GameReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private GameLevelCamera _followCamera;
    [SerializeField] private SkillStorage _skillStorage;
    [SerializeField] private SkillsConteinerUI _skillConteinerUI;
    [SerializeField] private DIGameConteiner _dIGameConteiner;
    [SerializeField] private StateMashineUI _stateMashineUI;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(
            _gameSession,
            typeof(IGameLevels),
            typeof(IGamePlayer),
            typeof(IGameProgress),
            typeof(IPlayerAbilities),
            typeof(IGameLevelSettings));

        containerBuilder.AddSingleton(_followCamera);
        containerBuilder.AddSingleton(_skillStorage);
        containerBuilder.AddSingleton(_skillConteinerUI);
        containerBuilder.AddSingleton(_dIGameConteiner);
        containerBuilder.AddSingleton(_stateMashineUI);
    }
}