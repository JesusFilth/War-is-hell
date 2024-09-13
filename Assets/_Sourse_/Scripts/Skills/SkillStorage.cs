using Reflex.Attributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkillStorage : MonoBehaviour
{
    [SerializeField] private List<Skill> _skills = new List<Skill>();

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

    public Skill[] GetThreeRandomSkill()
    {
        const int CountSkills = 3;

        List<Skill> result = new List<Skill>();
        Skill[] skills = _skills.Where(skill=>skill.IsMaxLevel == false).ToArray();

        do
        {
            int random = Random.Range(0, skills.Length);

            if (result.Contains(skills[random]) == false)
                result.Add(skills[random]);
        }
        while (result.Count != CountSkills);

        return result.ToArray();
    }
}
