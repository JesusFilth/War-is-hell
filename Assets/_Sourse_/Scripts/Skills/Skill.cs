using System;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [Space]
    [Header("Skill abstract settings")]
    [SerializeField] protected int Level;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private SkillItem _item;
    [SerializeField] [TextArea(3,5)] private string _description;

    public int LevelNumber => Level;
    public bool IsMaxLevel { get; protected set; }
    public SkillItem Item => _item;
    public Sprite Icon => _icon;
    public string Name => _name;
    public string Description => _description;

    protected SkillExecuteStratigy Stratigy = new SkillExecuteStratigy();

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