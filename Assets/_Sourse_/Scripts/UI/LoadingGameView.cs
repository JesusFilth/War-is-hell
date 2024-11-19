using Reflex.Attributes;
using Sourse.Scripts.Core.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace Sourse.Scripts.UI
{
    public class LoadingGameView : MonoBehaviour
    {
        [SerializeField] private Image _screen;

        [Inject] private ILoadScreens _loadScreens;
        private void Awake()
        {
            _screen.sprite = _loadScreens.GetRandomScreen();
        }
    }
}
