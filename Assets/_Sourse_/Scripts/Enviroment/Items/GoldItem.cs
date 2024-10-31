using Reflex.Attributes;
using UnityEngine;

public class GoldItem : Item
{
    [SerializeField] private int _count;

    [Inject] private IGameLevel _level;
    [Inject] private IGameLevelSettings _gameLevelSettings;

    private void Start()
    {
        DIGameConteiner.Instance.InjectRecursive(gameObject);
        Initialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.AddGold(_count);
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        const float MaxPercent = 100;

        int level = _level.GetCurrentLevelNumber();
        float percentUp = (_gameLevelSettings.GetUpLevelPowerPercent() * level) / MaxPercent;
        float upResult = _count * percentUp;

        _count = _count + (int)upResult;
    }
}
