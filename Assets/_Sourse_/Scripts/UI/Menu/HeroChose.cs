using System;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Runtime.Characters;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class HeroChose : MonoBehaviour
{
    [SerializeField] private Character _character;

    //[SerializeField] private Transform _heroseContainer;

    [SerializeField] private Button _next;
    [SerializeField] private Button _prev;
    [SerializeField] private Button _buy;
    [SerializeField] private Button _select;

    //private HeroSetting _currentHero;
    //private Dictionary<string, Hero> _herosModels = new();
    private int _currentIndex = 0;

    [Inject] private IHeroStorage _heroes;

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
        _currentIndex = Mathf.Clamp(_currentIndex += 1, 0, _heroes.GetHeroes().Count-1);
        UpdateChoseHero();
    }

    public void Prev()
    {
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
    }
}
