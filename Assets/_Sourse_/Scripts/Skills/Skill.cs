using System;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private SkillItem _item;

    public int Level { get; protected set; } = 1;
    public bool IsMaxLevel { get; protected set; }
    public SkillItem Item => _item;

    protected SkillExecuteStratigy Stratigy = new SkillExecuteStratigy();

    public string Name => _name;
    public Sprite Icon => _icon;

    private void OnValidate()
    {
        if (_item == null)
            throw new ArgumentNullException(nameof(_item));
    }

    public abstract void ExecuteStratigy(PlayerAbilitys abilitys);

    public abstract void UpSkill();

    public virtual string GetDescription() => "";

    protected abstract void CheckMaxLevel();
}