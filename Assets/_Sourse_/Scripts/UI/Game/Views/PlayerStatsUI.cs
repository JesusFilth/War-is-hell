using GameCreator.Runtime.Common;
using GameCreator.Runtime.Stats;
using Reflex.Attributes;
using System.Drawing.Printing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PlayerStatsUI : MonoBehaviour, IGameUI
{
    private const string HPStat = "max_hp";
    private const string DamageStat = "Damage";
    private const string WeaponStat = "WeaponDamage";
    private const string SkillPowerStat = "SkillPower";

    [SerializeField] private SkillItemUI _skillPrefab;
    [SerializeField] private Transform _skillsConteiner;
    [SerializeField] private Button _close;
    [Space]
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _weapon;
    [SerializeField] private TMP_Text _skillPower;

    private CanvasGroup _canvasGroup;

    [Inject] private IPlayerAbilities _playerAbilities;
    [Inject] private StateMashineUI _stateMashineUI;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    private void OnEnable()
    {
        _close.onClick.AddListener(OnClickClose);
    }

    private void OnDisable()
    {
        _close.onClick.RemoveListener(OnClickClose);
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;

        TimeManager.Instance.SetTimeScale(0, 5);
        Time.timeScale = 0;

        UpdateSkills();
        UpdateStats();
    }

    private void UpdateSkills()
    {
        ClearConteiner();

        var skills = _playerAbilities.GetAbilities().SkillsStorage.Skills;

        foreach (SkillActive skill in skills)
        {
            SkillItemUI temp = Instantiate(_skillPrefab,_skillsConteiner);
            temp.Init(skill);
        }
    }

    private void UpdateStats()
    {
        Traits traits = _playerAbilities.GetAbilities().Traits;

        StatItem hp = traits.Class.GetStat(HPStat);
        StatItem damage = traits.Class.GetStat(DamageStat);
        StatItem weapon = traits.Class.GetStat(WeaponStat);
        StatItem skillPower = traits.Class.GetStat(SkillPowerStat);

        _health.text = hp.Base.ToString();
        _damage.text = damage.Base.ToString();
        _weapon.text = weapon.Base.ToString();
        _skillPower.text = skillPower.Base.ToString();
    }

    private void ClearConteiner()
    {
        for (int i = 0; i < _skillsConteiner.childCount; i++)
        {
            Destroy(_skillsConteiner.GetChild(i).gameObject);
        }
    }

    private void OnClickClose()
    {
        _stateMashineUI.EnterIn<GameLevelUIState>();
    }
}
