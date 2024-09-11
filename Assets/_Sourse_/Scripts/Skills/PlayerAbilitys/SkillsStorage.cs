using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkillsStorage : MonoBehaviour
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
                Execute(skill);
        }
    }

    public void AddSkill(SkillActive skillActive)
    {
        Debug.Log("Add Action Skill");
        _skills.Add(Instantiate(skillActive));
    }

    private void Initialize()
    {
        for (int i = 0; i < _skills.Count; i++)
        {
            _skills[i] = Instantiate(_skills[i]);
        }
    }

    private void Execute(SkillActive skill)//?
    {
        if (skill is SkillCurce curse)
            Execute(curse);
        if(skill is SkillRotation rotation)
            Execute(rotation);

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

    private void Execute(SkillRotation rotation)
    {
        if (rotation.CanActiveEffectForChance())
        {
            Instantiate(rotation.Effect);
        }
    }
}