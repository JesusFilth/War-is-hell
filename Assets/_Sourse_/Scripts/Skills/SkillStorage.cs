using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkillStorage : MonoBehaviour
{
    [SerializeField] private List<Skill> _skills = new List<Skill>();

    [Inject] private PlayerAbilitys _abilitys;

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

        do
        {
            int random = Random.Range(0, _skills.Count);

            if (result.Contains(_skills[random]) == false)
                result.Add(_skills[random]);
        }
        while (result.Count != CountSkills);

        return result.ToArray();
    }

    public void AddSkill_Test()//temp
    {
        _abilitys.AddSkill(_skills[0]);
    }
}
