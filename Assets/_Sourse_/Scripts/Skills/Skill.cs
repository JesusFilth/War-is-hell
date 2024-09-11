using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] private string Name;
    [SerializeField] private Sprite _icon;

    protected ISkillStratigy Stratigy;
    protected int Level = 1;

    public Sprite Icon => _icon;

    public abstract void ExecuteStratigy(PlayerAbilitys abilitys);

    public virtual string GetDescription() => "";
}