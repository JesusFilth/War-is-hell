using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActiveSkillsStorage : MonoBehaviour
{
    [SerializeField] private SkillsEnemyConteiner _conteiner;
    [SerializeField] private List<SkillActive> _skills = new();

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (_conteiner.HasEnemys == false)
            return;

        if (_skills.Count == 0)
            return;

        foreach (SkillActive skill in _skills)
        {
            if (skill.IsCooldawn == false)
                ChoseExecute(skill);
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
        {
            _skills[i] = Instantiate(_skills[i]);
        }
    }

    private void ChoseExecute(SkillActive skill)
    {
        if (skill is SkillEnemyTarget enemyTarget)
            Execute(enemyTarget);
        else if (skill is SkillDeadTarget deadTarget)
            Execute(deadTarget);
        else
            Execute(skill); 

        skill.Active();
    }

    private void Execute(SkillDeadTarget skill)
    {
        Debug.Log("1");
        for (int i = 0; i < skill.DeadCount; i++)
        {
            if (skill.CanActiveEffectForChance())
            {
                Debug.Log("2");
                Enemy[] deads = _conteiner.Enemys.Where(enemy => enemy.IsDead).ToArray();

                if (deads == null || deads.Length == 0)
                    continue;
                Debug.Log("Exp");
                int randomIndex = Random.Range(0, deads.Length);
                Instantiate(skill.Effect, deads[randomIndex].SkillPoint);
            }
        }
    }

    private void Execute(SkillEnemyTarget skill)
    {
        for (int i = 0; i < skill.EnemyCount; i++)
        {
            if (skill.CanActiveEffectForChance())
            {
                Enemy[] deads = _conteiner.Enemys.Where(enemy => enemy.IsDead == false).ToArray();

                if (deads == null || deads.Length == 0)
                    continue;

                int randomIndex = Random.Range(0, deads.Length);
                Instantiate(skill.Effect, deads[randomIndex].transform);
            }
        }
    }

    private void Execute(SkillActive skill)
    {
        if (skill.CanActiveEffectForChance())
        {
            Instantiate(skill.Effect);
        }
    }
}