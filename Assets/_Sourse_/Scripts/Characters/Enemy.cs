using Reflex.Attributes;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    [Inject] private IGameLevelSettings _settings;

    public bool IsDead { get; private set; }

    private void Awake()
    {
        DIGameConteiner.Instance.InjectRecursive(gameObject);
    }

    private void Start()
    {
        Initialize();
    }

    public void Die()
    {
        IsDead = true;
        Died?.Invoke(this);
    }

    private void Initialize()
    {
        Debug.Log("Enemy Stat Init");
    }
}