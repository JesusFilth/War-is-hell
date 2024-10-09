using System;
using Reflex.Attributes;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _skillPrefabPoint;

    private Skill _currentSkill;

    [Inject] private IGameLevel _gameLevels;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _gameLevels.LoadNextLevel(_currentSkill);
        }
    }

    public void SetSkill(Skill skill)
    {
        if (skill == null)
            throw new ArgumentNullException(nameof(skill));

        Instantiate(skill.Item, _skillPrefabPoint);
        _currentSkill = skill;
    }
}