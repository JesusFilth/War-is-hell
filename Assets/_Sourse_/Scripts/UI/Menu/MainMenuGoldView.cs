using Core.Storage;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class MainMenuGoldView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gold;

        [Inject] private UserStorage _userStorage;

        private void OnEnable()
        {
            _userStorage.GoldChanged += UpdateData;
            _userStorage.UpdateGold();
        }

        private void OnDisable()
        {
            _userStorage.GoldChanged -= UpdateData;
        }

        private void UpdateData(int gold)
        {
            _gold.text = gold.ToString();
        } 
    }
}