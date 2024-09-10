using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkillsStorage : MonoBehaviour
{
    [SerializeField] private SkillsEnemyConteiner _conteiner;
    [SerializeField] private List<Skill> _skills;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < _skills.Count; i++)
        {
            _skills[i] = Instantiate(_skills[i]);
        }
    }

    private void Update()
    {
        if (_conteiner.HasEnemys == false)
            return;

        foreach (Skill skill in _skills)
        {
            if (skill.IsCooldawn == false)
                ExecuteSkill(skill);
        }
    }

    private void ExecuteSkill(Skill skill)
    {
        if(skill is SkillCurce curce)
        {
            ExecureCurce(curce);
        }
        if(skill is SkillRotation rotation)
        {
            ExecureRotation(rotation);
        }


        skill.Active(Time.time);
    }

    private void ExecureRotation(SkillRotation rotation)
    {
        if (rotation.CanActiveEffect())
        {
            Instantiate(rotation.Effect);
        }
    }

    private void ExecureCurce(SkillCurce curce)
    {
        for (int i = 0; i < curce.EnemyCount; i++)
        {
            if (curce.CanActiveEffect())
            {
                CreateEffectRandomEnemy(curce.Effect);
            }
        }
    }

    private void CreateEffectRandomEnemy(SkillEffect effect)
    {
        int randomIndex = Random.Range(0, _conteiner.Enemys.Count);
        Instantiate(effect, _conteiner.Enemys.ElementAt(randomIndex).transform);
    }
}