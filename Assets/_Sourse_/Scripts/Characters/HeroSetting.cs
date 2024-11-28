using GamePush;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "Hero", menuName = "Pig Punch/HeroSetting", order = 2)]
    public class HeroSetting : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _russianName;
        [SerializeField] private string _englishName;
        [SerializeField] private string _turkishName;
        [SerializeField] private Hero _hero;
        [SerializeField] private GameObject _skin;
        [Space]
        [SerializeField] private int _price;
        [SerializeField] [TextArea(3, 10)] private string _russianDescription;
        [SerializeField] [TextArea(3, 10)] private string _englishDescription;
        [SerializeField] [TextArea(3, 10)] private string _turkishDescription;

        private string _name;
        private string _description;

        public string Id => _id;
        public string Name => _name;
        public Hero Hero => _hero;
        public GameObject Skin => _skin;
        public string Description => _description;
        public int Price => _price;

        public void ChangeLanguage(Language languageCode)
        {
            switch (languageCode)
            {
                case Language.English:
                    _name = _englishName;
                    _description = _englishDescription;
                    break;
                case Language.Turkish:
                    _name = _turkishName;
                    _description = _turkishDescription;
                    break;
                case Language.Russian:
                    _name = _russianName;
                    _description = _russianDescription;
                    break;
            }
        }
    }
}
