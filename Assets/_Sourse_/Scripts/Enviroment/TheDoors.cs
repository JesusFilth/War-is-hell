using System;
using Reflex.Attributes;
using UnityEngine;

public class TheDoors : MonoBehaviour
{
    [SerializeField] private Door[] _doors;

    [Inject] private SkillStorage _skillStorage;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (_doors == null || _doors.Length == 0)
            throw new ArgumentNullException(nameof(_doors));

        Skill[] skills = _skillStorage.GetRandomSkills(_doors.Length);

        for (int i = 0; i < skills.Length; i++)
        {
            _doors[i].SetSkill(skills[i]);
        }
    }
}
