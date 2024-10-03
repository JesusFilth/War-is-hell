using IJunior.TypedScenes;
using Reflex.Attributes;
using UnityEngine;

public class OnGameLevelLoaded : MonoBehaviour, ISceneLoadHandler<LevelLocation>
{
    [Inject] private DIGameConteiner _dIConteiner;
    [Inject] private IGameLevels _gameLevels;
    [Inject] private IGamePlayer _player;

    public void OnSceneLoaded(LevelLocation level)
    {
        _dIConteiner.InitHot();
        _gameLevels.LoadGameLevel();
    }
}
