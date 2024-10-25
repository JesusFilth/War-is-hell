using GameCreator.Runtime.Stats;
using TMPro;
using UnityEngine;

public class HeroStatsView : MonoBehaviour
{
    private const string HPStat = "max_hp";
    private const string DamageStat = "Damage";
    private const string WeaponStat = "WeaponDamage";

    [SerializeField] private HeroChose _heroChose;
    [Space]
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _weapon;
    [SerializeField] private TMP_Text _description;

    private void OnEnable()
    {
        _heroChose.HeroChanged += UpdateData;
    }

    private void OnDisable()
    {
        _heroChose.HeroChanged -= UpdateData;
    }

    private void UpdateData(HeroSetting heroSetting)
    {
        Hero hero = heroSetting.Hero;
        
        if(hero.gameObject.TryGetComponent(out Traits traits))
        {
            StatItem hp = traits.Class.GetStat(HPStat);
            StatItem damage = traits.Class.GetStat(DamageStat);
            StatItem weapon = traits.Class.GetStat(WeaponStat);

            _health.text = hp.Base.ToString();
            _damage.text = damage.Base.ToString();
            _weapon.text = weapon.Base.ToString();
        }

        _description.text = heroSetting.Description;
    }
}
