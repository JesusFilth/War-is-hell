using GameCreator.Runtime.Common;
using Reflex.Attributes;
using Sourse.Scripts.Skills;
using Sourse.Scripts.UI.Game.FMS;
using Sourse.Scripts.UI.Game.FMS.States;
using UnityEngine;

namespace Sourse.Scripts.UI.Game.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class SkillsConteinerUI : MonoBehaviour, IGameUI
    {
        private const int MaxSkill = 3;

        [SerializeField] private SkillItemUI[] _skillItems = new SkillItemUI[MaxSkill];

        private CanvasGroup _canvasGroup;

        [Inject] private SkillStorage _skillStorage;
        [Inject] private StateMashineUI _stateMashineUI;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnValidate()
        {
            if(_skillItems.Length != MaxSkill)
                _skillItems = new SkillItemUI[MaxSkill];
        }

        public void Open()
        {
            _stateMashineUI.EnterIn<SkillUIState>();
        }

        public void Show()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;

            TimeManager.Instance.SetTimeScale(0,5);

            UpdateData();
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;

            TimeManager.Instance.SetTimeScale(1, 5);
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
