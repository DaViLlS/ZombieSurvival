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
            _inputHandler.OnMovementPerformed += OnMovementPerformed;
            _inputHandler.OnMovementCancelled += OnMovementCancelled;
            _inputHandler.OnShiftPerformed += OnShiftPerformed;
            _inputHandler.OnShiftCancelled += OnShiftCancelled;
            _inputHandler.OnJumpPerformed += OnJumpPerformed;
        }

        private void OnMovementPerformed()
        {
            weapon.WalkAnimation(true);
        }

        private void OnMovementCancelled()
        {
            weapon.WalkAnimation(false);
        }

        private void OnShiftPerformed()
        {
            weapon.RunAnimation(true);
        }

        private void OnShiftCancelled()
        {
            weapon.RunAnimation(false);
        }

        private void OnJumpPerformed()
        {
            
        }

        private void OnJumpCancelled()
        {
            
        }
    }
}