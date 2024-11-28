using UI.Game.Buttons;
using UnityEngine;

namespace UI.Menu
{
    public class PlayerSettingButton : ButtonView
    {
        [SerializeField] private GameObject _mainUi;
        [SerializeField] private GameObject _settingUi;

        protected override void OnClick()
        {
            _mainUi.SetActive(false);
            _settingUi.SetActive(true);
        }
    }
}
