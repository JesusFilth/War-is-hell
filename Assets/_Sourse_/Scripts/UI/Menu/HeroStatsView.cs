using Characters;
using GameCreator.Runtime.Stats;
using GamePush;
using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class HeroStatsView : MonoBehaviour
    {
        private const string HPStat = "max_hp";
        private const string DamageStat = "Damage";
        private const string WeaponStat = "WeaponDamage";
        private const string SkillPowerStat = "SkillPower";

        [SerializeField] private HeroChose _heroChose;
        [Space]
        [SerializeField] private TMP_Text _health;
        [SerializeField] private TMP_Text _damage;
        [SerializeField] private TMP_Text _weapon;
        [SerializeField] private TMP_Text _skillPower;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _name;

        private void OnEnable()
        {
            _heroChose.HeroChanged += OnUpdateData;
        }

        private void OnDisable()
        {
            _heroChose.HeroChanged -= OnUpdateData;
        }

        private void OnUpdateData(HeroSetting heroSetting)
        {
            heroSetting.ChangeLanguage(GP_Language.Current());

            Hero hero = heroSetting.Hero;

            _name.text = heroSetting.Name;
        
            if(hero.gameObject.TryGetComponent(out Traits traits))
            {
                StatItem hp = traits.Class.GetStat(HPStat);
                StatItem damage = traits.Class.GetStat(DamageStat);
                StatItem weapon = traits.Class.GetStat(WeaponStat);
                StatItem skillPower = traits.Class.GetStat(SkillPowerStat);

                _health.text = hp.Base.ToString();
                _damage.text = damage.Base.ToString();
                _weapon.text = weapon.Base.ToString();
                _skillPower.text = skillPower.Base.ToString();
            }

            _description.text = heroSetting.Description;
        }
    }
}
