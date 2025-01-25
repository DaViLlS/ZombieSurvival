using _Project.Development.ZombieSurvivalCore.Enemies;
using _Project.Development.ZombieSurvivalCore.MainCharacter;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Installers
{
    public class GameLevelInstaller : MonoInstaller
    {
        [SerializeField] private Character character;
        [SerializeField] private Transform playerSpawnPoint;
        [Space]
        [SerializeField] private EnemiesManager enemiesManager;

        public override void InstallBindings()
        {
            var inputHandler = Container.InstantiatePrefabForComponent<Character>(character, playerSpawnPoint);
            Container.Bind<Character>().FromInstance(inputHandler).AsSingle();
            Container.Bind<EnemiesManager>().FromInstance(enemiesManager).AsSingle();
        }
    }
}