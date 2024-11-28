using System;
using Characters;
using Core.Storage;
using GameCreator.Runtime.Characters;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class HeroChose : MonoBehaviour
    {
        [SerializeField] private Character _character;

        [SerializeField] private Button _next;
        [SerializeField] private Button _prev;

        [SerializeField] private Button _buy;
        [SerializeField] private GameObject _select;
        [SerializeField] private GameObject _lock;
        [SerializeField] private TMP_Text _price;

        private int _currentIndex = 0;

        [Inject] private IHeroStorage _heroes;
        [Inject] private UserStorage _userStorage;

        public event Action<HeroSetting> HeroChanged;

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            HeroChanged?.Invoke(_heroes.GetHeroes()[_currentIndex]);
        }

        private void OnEnable()
        {
            _next.onClick.AddListener(Next);
            _prev.onClick.AddListener(Prev);
            _buy.onClick.AddListener(Buy);
        }

        private void OnDisable()
        {
            _next.onClick.RemoveListener(Next);
            _prev.onClick.RemoveListener(Prev);
            _buy.onClick.RemoveListener(Buy);
        }

        private void Next()
        {
            if (_currentIndex == _heroes.GetHeroes().Count - 1)
                return;

            _currentIndex = Mathf.Clamp(_currentIndex += 1, 0, _heroes.GetHeroes().Count-1);
            UpdateChoseHero();
        }

        private void Prev()
        {
            if (_currentIndex == 0)
                return;

            _currentIndex = Mathf.Clamp(_currentIndex -= 1, 0, _heroes.GetHeroes().Count-1);
            UpdateChoseHero();
        }

        private void Buy()
        {
            HeroSetting hero = _heroes.GetHeroes()[_currentIndex];

            if (hero.Price > _userStorage.UserGold)
                return;

            _userStorage.AddHero(hero.Id, -hero.Price);

            UpdateButtons(hero);
        }

        private void Initialize()
        {
            _heroes.SetCurrentHero(_heroes.GetHeroes()[_currentIndex]);
            UpdateChoseHero();
        }

        private void UpdateButtons(HeroSetting heroSetting)
        {
            if (_userStorage.HasHero(heroSetting.Id))
            {
                _buy.gameObject.SetActive(false);
                _select.SetActive(true);
                _lock.SetActive(false);

                _heroes.SetCurrentHero(_heroes.GetHeroes()[_currentIndex]);
            }
            else
            {
                _price.text = heroSetting.Price.ToString();
                _buy.gameObject.SetActive(true);
                _select.SetActive(false);
                _lock.SetActive(true);
            }
        }

        private void UpdateChoseHero()
        {
            HeroSetting heroSetting = _heroes.GetHeroes()[_currentIndex];
            GameObject skin = heroSetting.Skin;

            _character.ChangeModel(skin, new Character.ChangeOptions
            {
                materials = null,
                offset = Vector3.zero
            });

            UpdateButtons(heroSetting);
        
            HeroChanged?.Invoke(_heroes.GetHeroes()[_currentIndex]);
        }
    }
}
