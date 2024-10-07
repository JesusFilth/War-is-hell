using System;
using GameCreator.Runtime.Stats;
using Reflex.Attributes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string LevelID = "level";
    private const float DelayDieDestroy = 10f;

    [SerializeField] private Traits _traits;
    [SerializeField] private Transform _skillPoint;

    [Inject] private IGameProgress _progress;

    public Transform SkillPoint => _skillPoint;
    public bool IsDead { get; private set; }

    public event Action<Enemy> Died;

    private void Awake()
    {
        if(DIGameConteiner.Instance != null)
        {
            DIGameConteiner.Instance.InjectRecursive(gameObject);
            Initialize();
        }
    }

    public void Die()
    {
        transform.parent = null;
        Destroy(gameObject, DelayDieDestroy);

        IsDead = true;
        Died?.Invoke(this);
    }

    private void Initialize()
    {
        RuntimeStatData runtimeStat = _traits.RuntimeStats.Get(LevelID);
        runtimeStat.AddModifier(ModifierType.Constant, _progress.GetPlayerProgress().LevelCount);
    }
}