using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Pig Punch/HeroSetting", order = 2)]
public class HeroSetting : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Hero _hero;
    [SerializeField] private GameObject _skin;
    [SerializeField] private float _price;

    public string Name => _name;
    public Hero Hero => _hero;
    public GameObject Skin => _skin;
    public float Price => _price;
}
