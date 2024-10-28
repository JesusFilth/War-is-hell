using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class LoadingGameView : MonoBehaviour
{
    [SerializeField] private Image _screen;

    [Inject] private ILoadScreens _loadScreens;
    private void Awake()
    {
        _screen.sprite = _loadScreens.GetRandomScreen();
    }
}
