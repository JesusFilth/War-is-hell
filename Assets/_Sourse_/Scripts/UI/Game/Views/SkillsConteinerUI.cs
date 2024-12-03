using GameCreator.Runtime.Common;
using Reflex.Attributes;
using Skills;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;

namespace UI.Game.Views
{
    public class SkillsConteinerUI : GameView
    {
        private const int MaxSkill = 3;

        [SerializeField] private SkillItemUI[] _skillItems = new SkillItemUI[MaxSkill];

        [Inject] private SkillStorage _skillStorage;
        [Inject] private StateMashineUI _stateMashineUI;


        private void OnValidate()
        {
            if(_skillItems.Length != MaxSkill)
                _skillItems = new SkillItemUI[MaxSkill];
        }

        public override void Show()
        {
            SetCanvasVisibility(true);

            TimeManager.Instance.SetTimeScale(1);

            UpdateData();
        }

        public override void Hide()
        {
            SetCanvasVisibility(false);
        }

        public void Open()
        {
            _stateMashineUI.EnterIn<SkillUIState>();
        }

        public void UpdateData()
        {
            Skill[] skills = _skillStorage.GetRandomSkills(MaxSkill);

            for (int i = 0; i <_skillItems.Length; i++)
            {
                _skillItems[i].Init(skills[i], 1);
            }
        }
    }
}
