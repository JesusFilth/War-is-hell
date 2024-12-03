using Core.GameSession;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Stats;
using Reflex.Attributes;
using Skills;
using TMPro;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game.Views
{
    public class PlayerStatsUI : GameView
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

        [Inject] private IPlayerAbilities _playerAbilities;
        [Inject] private StateMashineUI _stateMashineUI;

        private void OnEnable()
        {
            _close.onClick.AddListener(OnClickClose);
        }

        private void OnDisable()
        {
            _close.onClick.RemoveListener(OnClickClose);
        }

        public override void Hide()
        {
            SetCanvasVisibility(false);
        }

        public override void Show()
        {
            SetCanvasVisibility(true);

            TimeManager.Instance.SetTimeScale(0);

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

            var hp = traits.RuntimeStats.Get(HPStat); 
            var damage = traits.RuntimeStats.Get(DamageStat);
            var weapon = traits.RuntimeStats.Get(WeaponStat);
            var skillPower = traits.RuntimeStats.Get(SkillPowerStat);

            _health.text = hp.Value.ToString();
            _damage.text = damage.Value.ToString();
            _weapon.text = weapon.Value.ToString();
            _skillPower.text = skillPower.Value.ToString();
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
}
