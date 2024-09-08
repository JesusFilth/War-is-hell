using Reflex.Core;
using UnityEngine;

public class GameLevelReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private Player _player;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_player);
    }
}
