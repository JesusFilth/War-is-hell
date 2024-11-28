using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Skills
{
    public class SkillStorage : MonoBehaviour
    {
        [SerializeField] private List<Skill> _skills = new List<Skill>();

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _skills.Count; i++)
            {
                _skills[i] = Instantiate(_skills[i]);
            }
        }

        public Skill[] GetRandomSkills(int count)
        {
            if (_skills == null || _skills.Count == 0)
                throw new ArgumentNullException(nameof(_skills));

            if (_skills.Count <= count)
                throw new InvalidOperationException(nameof(count));

            List<Skill> result = new List<Skill>();
            Skill[] skills = _skills.Where(skill => skill.IsMaxLevel == false).ToArray();

            do
            {
                int random = Random.Range(0, skills.Length);

                if (result.Contains(skills[random]) == false)
                    result.Add(skills[random]);
            }
            while (result.Count != count);

            return result.ToArray();
        }
    }
}