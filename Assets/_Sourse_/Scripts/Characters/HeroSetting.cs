using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Pig Punch/HeroSetting", order = 2)]
public class HeroSetting : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private Hero _hero;
    [SerializeField] private GameObject _skin;
    [Space]
    [SerializeField] private int _price;
    [SerializeField] [TextArea(3, 10)] private string _description;

    public string Id => _id;
    public string Name => _name;
    public Hero Hero => _hero;
    public GameObject Skin => _skin;
    public string Description => _description;
    public int Price => _price;
}
