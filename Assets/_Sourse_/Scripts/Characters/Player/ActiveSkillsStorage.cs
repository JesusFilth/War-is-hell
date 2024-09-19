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
        if (skill is SkillCurce curse)
            Execute(curse);
        else
            Execute(skill); 

        skill.Active();
    }

    private void Execute(SkillCurce curse)
    {
        for (int i = 0; i < curse.EnemyCount; i++)
        {
            if (curse.CanActiveEffectForChance())
            {
                int randomIndex = Random.Range(0, _conteiner.Enemys.Count);
                Instantiate(curse.Effect, _conteiner.Enemys.ElementAt(randomIndex).transform);
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