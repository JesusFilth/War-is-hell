using System;
using UnityEngine;

public class PlayerAbilitys : MonoBehaviour
{
    [SerializeField] private Stats _stats;
    [SerializeField] private ActiveSkillsStorage _skillsStorage;

    public Stats Stats => _stats;
    public ActiveSkillsStorage SkillsStorage => _skillsStorage;

    private void OnValidate()
    {
        if (_stats == null)
            throw new ArgumentNullException(nameof(_stats));

        if(_skillsStorage == null)
            throw new ArgumentNullException(nameof(_skillsStorage));
    }

    public void AddSkill(Skill skill)//temp
    {
        Skill temp = Instantiate(skill);

        temp.ExecuteStratigy(this);
    }
}