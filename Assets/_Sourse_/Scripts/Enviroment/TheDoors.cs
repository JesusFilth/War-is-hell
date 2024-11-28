using System;
using Core.GameSession;
using Core.Storage;
using Reflex.Attributes;
using Skills;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enviroment
{
    public class TheDoors : MonoBehaviour
    {
        [SerializeField] private Door[] _doors;

        [Inject] private SkillStorage _skillStorage;
        [Inject] private ILevelsStorage _levelsStorage;
        [Inject] private IGameLevel _gameLevel;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_doors == null || _doors.Length == 0)
                throw new ArgumentNullException(nameof(_doors));

            if(_gameLevel.GetCurrentMode() == GameMode.Company)
            {
                if(_levelsStorage.GetLastLevelNumber() == _gameLevel.GetCurrentLevelNumber())
                {
                    int randomIndexDoor = Random.Range(0, _doors.Length);

                    for (int i = 0; i < _doors.Length; i++)
                    {
                        _doors[i].gameObject.SetActive(randomIndexDoor == i);
                    }

                    return;
                }
            }

            Skill[] skills = _skillStorage.GetRandomSkills(_doors.Length);

            for (int i = 0; i < skills.Length; i++)
            {
                _doors[i].SetSkill(skills[i]);
            }
        }
    }
}
