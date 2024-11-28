using GameCreator.Runtime.Common;
using Reflex.Attributes;
using Skills;
using UI.Game.FMS;
using UI.Game.FMS.States;
using UnityEngine;

namespace UI.Game.Views
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
            const int LayerTime = 5;

            SetCanvasVisibility(true);

            TimeManager.Instance.SetTimeScale(1, LayerTime);

            UpdateData();
        }

        public void Hide()
        {
            SetCanvasVisibility(false);

        }

        public void UpdateData()
        {
            Skill[] skills = _skillStorage.GetRandomSkills(MaxSkill);

            for (int i = 0; i <_skillItems.Length; i++)
            {
                _skillItems[i].Init(skills[i], 1);
            }
        }

        private void SetCanvasVisibility(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.interactable = isActive;
            _canvasGroup.blocksRaycasts = isActive;
        }
    }
}
