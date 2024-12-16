using Assets._Project.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

public class InputHandlerInstaller : MonoInstaller
{
    [SerializeField] private InputHandler inputHandlerPrefab;

    public override void InstallBindings()
    {
        var inputHandler = Container.InstantiatePrefabForComponent<InputHandler>(inputHandlerPrefab);
        Container.Bind<InputHandler>().FromInstance(inputHandler).AsSingle();
    }
}