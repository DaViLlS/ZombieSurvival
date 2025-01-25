using _Project.Development.Core.UIBase;
using _Project.Development.ZombieSurvivalCore.Enemies;
using _Project.Development.ZombieSurvivalCore.MainCharacter;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Installers
{
    public class GameLevelInstaller : MonoInstaller
    {
        [SerializeField] private Character characterPrefab;
        [SerializeField] private Transform playerSpawnPoint;
        [Space]
        [SerializeField] private EnemiesManager enemiesManager;
        [Space]
        [SerializeField] private UISystem uiSystem;

        public override void InstallBindings()
        {
            Container.Bind<UISystem>().FromInstance(uiSystem).AsSingle();
            var character = Container.InstantiatePrefabForComponent<Character>(characterPrefab, playerSpawnPoint);
            Container.Bind<Character>().FromInstance(character).AsSingle();
            Container.Bind<EnemiesManager>().FromInstance(enemiesManager).AsSingle();
        }
    }
}