using Reflex.Attributes;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    [Inject] private LevelStorage _levelStorage;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _levelStorage.ToNextRandomLevel();
        }
    }
}