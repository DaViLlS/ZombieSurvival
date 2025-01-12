using _Project.Development.Core.PlayerInput;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Weapons;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Hands
{
    public class HandsController : MonoBehaviour
    {
        [Inject] private InputHandler _inputHandler;
        
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private Weapon weapon;
        
        public Weapon Weapon => weapon;

        public void Initialize()
        {
            stateMachine.Initialize();
        }
    }
}