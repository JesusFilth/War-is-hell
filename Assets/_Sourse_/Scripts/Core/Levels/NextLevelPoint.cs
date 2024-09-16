using Reflex.Attributes;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    [Inject] private GameLevelStorage _levelStorage;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _levelStorage.LoadGameLevel();
        }
    }
}