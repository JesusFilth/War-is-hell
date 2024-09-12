using Reflex.Attributes;
using UnityEngine;

public class SkillsConteinerUI : MonoBehaviour
{
    private const int MaxSkill = 3;

    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] private SkillItemUI[] _skillItems = new SkillItemUI[MaxSkill];

    [Inject] private SkillStorage _skillStorage;

    private void OnValidate()
    {
        if(_skillItems.Length!=MaxSkill)
            _skillItems = new SkillItemUI[MaxSkill];
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;

        UpdateData();
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    public void UpdateData()
    {
        Skill[] skills = _skillStorage.GetThreeRandomSkill();

        for (int i = 0; i <_skillItems.Length; i++)
        {
            _skillItems[i].Init(skills[i]);
        }
    }
}
