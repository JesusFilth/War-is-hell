using IJunior.TypedScenes;
using Reflex.Attributes;
using UnityEngine;

public class OnGameLevelLoaded : MonoBehaviour, ISceneLoadHandler<LevelLocation>
{
    [Inject] private LevelStorage _levelStorage;
    [Inject] private FollowCameraToPlayerX _camera;
    [Inject] private DIGameConteiner _dIConteiner;

    public void OnSceneLoaded(LevelLocation level)
    {
        _dIConteiner.InitHot();

        LevelLocation levelLocation = Instantiate(level);
        _levelStorage.Player.transform.position = levelLocation.PlayerStartPosition.position;

        _camera.SetTarget(_levelStorage.Player.transform);
    }
}
