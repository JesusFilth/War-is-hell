using Reflex.Attributes;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.Core.Storage;
using Sourse.Scripts.DI;
using UnityEngine;

namespace Sourse.Scripts.Enviroment
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _damage;

        [Inject] private IGameLevel _level;
        [Inject] private IGameLevelSettings _gameLevelSettings;

        private void Start()
        {
            if(DIGameConteiner.Instance != null)
            {
                DIGameConteiner.Instance.InjectRecursive(gameObject);
                Initialize();
            }
        }

        private void Initialize()
        {
            const float MaxPercent = 100;

            int level = _level.GetCurrentLevelNumber();
            float percentUp = (_gameLevelSettings.GetUpLevelPowerPercent() * level) / MaxPercent;
            float upResult = _damage * percentUp;

            _damage = _damage + upResult;
        }
    }
}
