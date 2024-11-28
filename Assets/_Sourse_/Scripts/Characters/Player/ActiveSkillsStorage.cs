using System.Collections.Generic;
using System.Linq;
using Skills;
using Skills.SkillEffects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.Player
{
    public class ActiveSkillsStorage : MonoBehaviour
    {
        [SerializeField] private SkillsEnemyConteiner _conteiner;
        [SerializeField] private List<SkillActive> _skills = new();

        public IReadOnlyList<SkillActive> Skills => _skills;

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if (_skills.Count == 0)
                return;

            foreach (SkillActive skill in _skills)
            {
                if (skill.IsCooldawn == false)
                    ChoiceExecute(skill);
            }
        }

        public void AddSkill(SkillActive skillActive)
        {
            if(_skills.Contains(skillActive))
                skillActive.UpSkill();
            else
                _skills.Add(skillActive);
        }

        private void Initialize()
        {
            for (int i = 0; i < _skills.Count; i++)
                _skills[i] = Instantiate(_skills[i]);
        }

        private void ChoiceExecute(SkillActive skill)
        {
            if (skill is SkillEnemyTarget enemyTarget)
                Execute(enemyTarget);
            else if (skill is SkillDeadTarget deadTarget)
                Execute(deadTarget);
            else if (skill is SkillPlayerTarget playerTarget)
                Execute(playerTarget);
            else
                Execute(skill); 

            skill.Active();
        }

        private bool TryGetRandomEnemyTarget(bool isAlive, out Enemy enemy)
        {
            enemy = null;

            if (_conteiner.HasEnemys == false)
                return false;

            Enemy[] targets = _conteiner.Enemys.Where(enemy => enemy.IsDead == isAlive).ToArray();

            if (targets.Length == 0)
                return false;

            enemy = targets[Random.Range(0, targets.Length)];

            return true;
        }

        private void Execute(SkillDeadTarget skill)
        {
            for (int i = 0; i < skill.DeadCount; i++)
            {
                if (skill.CanActiveEffectForChance() == false)
                    continue;

                if(TryGetRandomEnemyTarget(false, out Enemy target))
                {
                    SkillEffect effect = Instantiate(skill.Effect);
                    effect.transform.position = target.SkillPoint.position;
                    Destroy(target.gameObject);
                }
            }
        }

        private void Execute(SkillEnemyTarget skill)
        {
            for (int i = 0; i < skill.EnemyCount; i++)
            {
                if (skill.CanActiveEffectForChance() == false)
                    return;

                if (TryGetRandomEnemyTarget(false, out Enemy target))
                {
                    Instantiate(skill.Effect, target.transform);
                }
            }
        }

        private void Execute(SkillPlayerTarget skill)
        {
            if (skill.CanActiveEffectForChance())
                skill.CreateEffect();
        }

        private void Execute(SkillActive skill)
        {
            if (skill.CanActiveEffectForChance())
                Instantiate(skill.Effect);
        }
    }
}