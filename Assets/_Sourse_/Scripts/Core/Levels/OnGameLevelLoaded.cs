using IJunior.TypedScenes;
using Reflex.Attributes;
using UnityEngine;

public class OnGameLevelLoaded : MonoBehaviour, ISceneLoadHandler<LevelLocation>
{
    [Inject] private GameLevelStorage _levelStorage;
    [Inject] private FollowCameraToPlayerX _camera;
    [Inject] private DIGameConteiner _dIConteiner;

    public void OnSceneLoaded(LevelLocation level)
    {
        _dIConteiner.InitHot();

        LevelLocation levelLocation = Instantiate(level);
        _levelStorage.InitPlayer(levelLocation.PlayerStartPosition.position);
        _levelStorage.Player.Progress.AddLevel();

        _camera.SetTarget(_levelStorage.Player.Transform);
    }
}
