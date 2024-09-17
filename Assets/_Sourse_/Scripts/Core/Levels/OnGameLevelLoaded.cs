using IJunior.TypedScenes;
using Reflex.Attributes;
using UnityEngine;

public class OnGameLevelLoaded : MonoBehaviour, ISceneLoadHandler<LevelLocation>
{
    [Inject] private FollowCameraToPlayerX _camera;
    [Inject] private DIGameConteiner _dIConteiner;
    [Inject] private IGameLevels _galeLevels;
    [Inject] private IGamePlayer _player;
    [Inject] private IGameProgress _progress;

    public void OnSceneLoaded(LevelLocation level)
    {
        _dIConteiner.InitHot();

        LevelLocation levelLocation = Instantiate(level);
        _galeLevels.InitPlayer(levelLocation.PlayerStartPosition.position);
        _progress.GetPlayerProgress().AddLevel();

        _camera.SetTarget(_player.GetPlayerPosition());
    }
}
