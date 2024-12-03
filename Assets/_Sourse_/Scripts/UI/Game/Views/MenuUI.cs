using Core.GameSession;
using GameCreator.Runtime.Common;
using Reflex.Attributes;
using TMPro;
using UI.Game.FMS;
using UnityEngine;

namespace UI.Game.Views
{
    public class MenuUI : GameView
    {
        [SerializeField] private TMP_Text _levelNumber;

        [Inject] private IGameLevel _level;

        public override void Hide()
        {
            SetCanvasVisibility(false);
        }

        public override void Show()
        {
            SetCanvasVisibility(true);

            _levelNumber.text = _level.GetCurrentLevelNumber().ToString();

            TimeManager.Instance.SetTimeScale(0);
        }
    }
}