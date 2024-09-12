using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int Level { get; protected set; } = 0;

    protected ISkillStratigy Stratigy;

    public string Name => _name;
    public Sprite Icon => _icon;

    public abstract void ExecuteStratigy(PlayerAbilitys abilitys);

    public virtual string GetDescription() => "";
}