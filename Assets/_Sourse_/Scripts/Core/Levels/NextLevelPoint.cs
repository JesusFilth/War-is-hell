using Reflex.Attributes;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    [Inject] private GameStateMashine _stateMashine;
    [Inject] private IGameLevels _gameLevels;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _stateMashine.EnterIn<LoadGameSceneState>();
        }
    }
}