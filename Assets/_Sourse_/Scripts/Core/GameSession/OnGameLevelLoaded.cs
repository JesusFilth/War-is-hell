using DI;
using IJunior.TypedScenes;
using Reflex.Attributes;
using UnityEngine;

namespace Core.GameSession
{
    public class OnGameLevelLoaded : MonoBehaviour, ISceneLoadHandler<GameMode>
    {
        [Inject] private DIGameConteiner _dIConteiner;
        [Inject] private IGameLevel _gameLevels;
        [Inject] private IGamePlayer _player;

        public void OnSceneLoaded(GameMode mode)
        {
            _dIConteiner.InitHot();
            _gameLevels.StartGame(_player, mode);
        }
    }
}
