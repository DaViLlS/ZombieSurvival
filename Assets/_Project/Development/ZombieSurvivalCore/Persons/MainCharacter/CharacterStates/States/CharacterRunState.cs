using _Project.Development.Core.StateMachine;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Persons.MainCharacter.CharacterStates.States
{
    public class CharacterRunState : IState
    {
        private CharacterStateMachine _stateMachine;
        private float _currentSpeed;

        private Rigidbody Rigidbody => _stateMachine.Character.Rigidbody;
        private Transform Transform => _stateMachine.Character.transform;

        public CharacterRunState(CharacterStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _currentSpeed = _stateMachine.Character.MovementSettings.ShiftSpeed;
        }

        public void OnEnterState()
        {
            _stateMachine.InputHandler.OnShiftCancelled += OnShiftCancelled;
            _stateMachine.InputHandler.OnJumpPerformed += OnJumpPerformed;
        }

        public void OnExitState()
        {
            _stateMachine.InputHandler.OnShiftCancelled -= OnShiftCancelled;
            _stateMachine.InputHandler.OnJumpPerformed -= OnJumpPerformed;
        }

        private void OnJumpPerformed()
        {
            _stateMachine.ChangeStateByType(CharacterStateType.Jump);
        }

        private void OnShiftCancelled()
        {
            if (_stateMachine.InputHandler.IsMovementPerformed)
            {
                _stateMachine.ChangeStateByType(CharacterStateType.Move);
            }
            else
            {
                _stateMachine.ChangeStateByType(CharacterStateType.Idle);
            }
        }

        public void Execute()
        {
        
        }

        public void FixedExecute()
        {
            var moveDirection = Transform.forward * _stateMachine.InputHandler.MovementVector.y + Transform.right * _stateMachine.InputHandler.MovementVector.x;
            Rigidbody.velocity = moveDirection * _currentSpeed + new Vector3(0f, Rigidbody.velocity.y, 0f);
        }
    }
}
