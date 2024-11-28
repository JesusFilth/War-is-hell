using Characters.Player;
using Core.GameSession;
using DI;
using Reflex.Attributes;
using Skills;
using UnityEngine;

namespace Enviroment
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
