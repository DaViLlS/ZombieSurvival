using _Project.Development.Core.PlayerInput;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Installers
{
    public class InputHandlerInstaller : MonoInstaller
    {
        [SerializeField] private InputHandler inputHandlerPrefab;

        public override void InstallBindings()
        {
            var inputHandler = Container.InstantiatePrefabForComponent<InputHandler>(inputHandlerPrefab);
            Container.Bind<InputHandler>().FromInstance(inputHandler).AsSingle();
        }
    }
}