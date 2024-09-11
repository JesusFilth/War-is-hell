using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

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

    public void AddSkill_Test()//temp
    {
        _abilitys.AddSkill(_skills[0]);
    }
}
