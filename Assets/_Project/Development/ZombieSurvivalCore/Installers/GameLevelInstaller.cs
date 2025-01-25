using _Project.Development.ZombieSurvivalCore.MainCharacter;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Installers
{
    public class GameLevelInstaller : MonoInstaller
    {
        [SerializeField] private Character character;
        [SerializeField] private Transform playerSpawnPoint;

        public override void InstallBindings()
        {
            var inputHandler = Container.InstantiatePrefabForComponent<Character>(character, playerSpawnPoint);
            Container.Bind<Character>().FromInstance(inputHandler).AsSingle();
        }
    }
}