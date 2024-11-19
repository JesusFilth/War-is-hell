using System;
using Reflex.Attributes;
using Sourse.Scripts.Characters.Player;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.Skills;
using UnityEngine;

namespace Sourse.Scripts.Enviroment
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform _skillPrefabPoint;

        private Skill _currentSkill;

        [Inject] private IGameLevel _gameLevels;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                _gameLevels.LoadNextLevel(_currentSkill);
            }
        }

        public void SetSkill(Skill skill)
        {
            if (skill == null)
                throw new ArgumentNullException(nameof(skill));

            Instantiate(skill.Item, _skillPrefabPoint);
            _currentSkill = skill;
        }
    }
}