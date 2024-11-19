using Reflex.Attributes;
using Sourse.Scripts.Characters.Player;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.DI;
using Sourse.Scripts.Skills;
using UnityEngine;

namespace Sourse.Scripts.Enviroment
{
    public class SkillItem : MonoBehaviour
    {
        private Skill _currentSkill;

        [Inject] private IPlayerAbilities _playerAbilities;

        private void Awake()
        {
            DIGameConteiner.Instance.InjectRecursive(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                if (_currentSkill == null)
                    return;

                _currentSkill.ExecuteStratigy(_playerAbilities.GetAbilities());
                Destroy(gameObject);
            }
        }

        public void Buinding(Skill skill)
        {
            _currentSkill = skill;
        }
    }
}
