using Characters.Player;
using Core.Camera;
using Core.GameSession;
using Reflex.Core;
using Skills;
using UI.Game.FMS;
using UI.Game.Views;
using UnityEngine;

namespace DI
{
    public class GameReflexDI : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameSession _gameSession;
        [SerializeField] private Player _player;
        [SerializeField] private GameLevelCamera _followCamera;
        [SerializeField] private SkillStorage _skillStorage;
        [SerializeField] private SkillsConteinerUI _skillConteinerUI;
        [SerializeField] private DIGameConteiner _dIGameConteiner;
        [SerializeField] private StateMashineUI _stateMashineUI;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(
                _player,
                typeof(IGamePlayer),
                typeof(IGameProgress),
                typeof(IPlayerAbilities));

            containerBuilder.AddSingleton(
                _gameSession,
                typeof(IGameLevel));

            containerBuilder.AddSingleton(_followCamera);
            containerBuilder.AddSingleton(_skillStorage);
            containerBuilder.AddSingleton(_skillConteinerUI);
            containerBuilder.AddSingleton(_dIGameConteiner);
            containerBuilder.AddSingleton(_stateMashineUI);
        }
    }
}