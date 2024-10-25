using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Pig Punch/HeroSetting", order = 2)]
public class HeroSetting : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Hero _hero;
    [SerializeField] private GameObject _skin;
    [Space]
    [SerializeField] private float _price;
    [SerializeField] [TextArea(3, 10)] private string _description;


    public string Name => _name;
    public Hero Hero => _hero;
    public GameObject Skin => _skin;
    public string Description => _description;
    public float Price => _price;
}
