using System;
using Core.GameSession;
using DI;
using GameCreator.Runtime.Stats;
using Reflex.Attributes;
using UnityEngine;

namespace Characters
{
    public class Enemy : MonoBehaviour
    {
        private const string LevelID = "level";
        private const float DelayDieDestroy = 10f;

        [SerializeField] private Traits _traits;
        [SerializeField] private Transform _skillPoint;
        [SerializeField] private int _score;

        [Inject] private IGameLevel _gameLevel;
        [Inject] private IGameProgress _gameProgress;

        public Transform SkillPoint => _skillPoint;
        public bool IsDead { get; private set; }

        public event Action<Enemy> Died;
        public event Action<Enemy> Destroed;

        private void Awake()
        {
            if(DIGameConteiner.Instance != null)
            {
                DIGameConteiner.Instance.InjectRecursive(gameObject);
                Initialize();
            }
        }

        private void OnDestroy()
        {
            Destroed?.Invoke(this);
        }

        public void Die()
        {
            if(_gameProgress != null)
                _gameProgress.GetPlayerProgress().AddScore(_score);

            transform.parent = null;
            Destroy(gameObject, DelayDieDestroy);

            IsDead = true;
            Died?.Invoke(this);
        }

        private void Initialize()
        {
            RuntimeStatData runtimeStat = _traits.RuntimeStats.Get(LevelID);
            runtimeStat.AddModifier(ModifierType.Constant, _gameLevel.GetCurrentLevelNumber() - 1);
        }
    }
}