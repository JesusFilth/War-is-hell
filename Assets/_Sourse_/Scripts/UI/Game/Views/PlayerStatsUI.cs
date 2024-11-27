using GameCreator.Runtime.Common;
using GameCreator.Runtime.Stats;
using Reflex.Attributes;
using Sourse.Scripts.Core.GameSession;
using Sourse.Scripts.Skills;
using Sourse.Scripts.UI.Game.FMS;
using Sourse.Scripts.UI.Game.FMS.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sourse.Scripts.UI.Game.Views
{
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
            const float AlphaHide = 0;

            _canvasGroup.alpha = AlphaHide;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }

        public void Show()
        {
            const int LayerTime = 5;
            const float TimeScale = 0;
            const float AlphaShow = 1;

            _canvasGroup.alpha = AlphaShow;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;

            TimeManager.Instance.SetTimeScale(TimeScale, LayerTime);

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
