using Reflex.Core;
using UnityEngine;

public class GameReflexDI : MonoBehaviour, IInstaller
{
    [SerializeField] private FollowCameraToPlayerX _followCamera;
    //[SerializeField] private Player _player;
    //[SerializeField] private PlayerAbilitys _playerAbility;
    [SerializeField] private SkillStorage _skillStorage;
    [SerializeField] private SkillsConteinerUI _skillConteinerUI;
    [SerializeField] private DIGameConteiner _dIGameConteiner;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_followCamera);
        //containerBuilder.AddSingleton(_player);
        //containerBuilder.AddSingleton(_playerAbility);
        containerBuilder.AddSingleton(_skillStorage);
        containerBuilder.AddSingleton(_skillConteinerUI);
        containerBuilder.AddSingleton(_dIGameConteiner);
    }
}