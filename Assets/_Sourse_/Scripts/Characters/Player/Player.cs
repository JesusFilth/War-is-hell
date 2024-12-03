using System.Collections;
using Core.GameSession;
using Core.Storage;
using Reflex.Attributes;
using UnityEngine;

namespace Characters.Player
{
    public class Player : MonoBehaviour,
        IGamePlayer,
        IGameProgress,
        IPlayerAbilities
    {
        private const float DelayPlayerPosition = 1f;
        private Coroutine _positionStarting;
        private WaitForSeconds _waitStartPosition = new WaitForSeconds(DelayPlayerPosition);

        private Hero _hero;

        [Inject] private IHeroStorage _heroStorage;

        public Transform Transform { get; private set; }
        public PlayerProgress Progress { get; private set; } = new();

        private void Awake()
        {
            Transform = transform;
            Initialize();
        }

        private void OnDisable()
        {
            if (_positionStarting != null)
            {
                StopCoroutine(_positionStarting);
                _positionStarting = null;
            }
        }

        public void AddExperience(float exp)
        {
            _hero.PlayerAbility.AddExperience(exp);
        }

        public void Resurrect()
        {
            _hero.PlayerAbility.Resurrect();
        }

        public PlayerProgress GetPlayerProgress()
        {
            return Progress;
        }

        public PlayerAbilities GetAbilities()
        {
            return _hero.PlayerAbility;
        }

        public void SetPosition(Vector3 position)
        {
            if(_positionStarting == null)
                _positionStarting = StartCoroutine(StartingPosition(position));
        }

        public void AddGold(int gold)
        {
            Progress.AddGold(gold);
        }

        private IEnumerator StartingPosition(Vector3 position)
        {
            yield return _waitStartPosition;
            _hero.Character.Driver.SetPosition(position);

            _positionStarting = null;
        }

        private void Initialize()
        {
            _hero = Instantiate(_heroStorage.GetCurrentHero().Hero);
            Transform.SetParent(_hero.transform);
            Transform.localPosition = Vector3.zero;
        }
    }
}