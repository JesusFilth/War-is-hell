using System;
using GameCreator.Runtime.Characters;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class HeroChose : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Button _next;
    [SerializeField] private Button _prev;
    [SerializeField] private Button _buy;
    [SerializeField] private Button _select;

    private int _currentIndex = 0;

    [Inject] private IHeroStorage _heroes;

    public event Action<HeroSetting> HeroChanged;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _next.onClick.AddListener(Next);
        _prev.onClick.AddListener(Prev);
    }

    private void OnDisable()
    {
        _next.onClick.RemoveListener(Next);
        _prev.onClick.RemoveListener(Prev);
    }

    public void Next()
    {
        if (_currentIndex == _heroes.GetHeroes().Count - 1)
            return;

        _currentIndex = Mathf.Clamp(_currentIndex += 1, 0, _heroes.GetHeroes().Count-1);
        UpdateChoseHero();
    }

    public void Prev()
    {
        if (_currentIndex == 0)
            return;

        _currentIndex = Mathf.Clamp(_currentIndex -= 1, 0, _heroes.GetHeroes().Count-1);
        UpdateChoseHero();
    }

    private void Initialize()
    {
        _heroes.SetCurrentHero(_heroes.GetHeroes()[_currentIndex]);
        UpdateChoseHero();
    }

    private void UpdateChoseHero()
    {
        GameObject skin = _heroes.GetHeroes()[_currentIndex].Skin;

        _character.ChangeModel(skin, new Character.ChangeOptions
        {
            materials = null,
            offset = Vector3.zero
        });

        _heroes.SetCurrentHero(_heroes.GetHeroes()[_currentIndex]);
        HeroChanged?.Invoke(_heroes.GetHeroes()[_currentIndex]);
    }
}
