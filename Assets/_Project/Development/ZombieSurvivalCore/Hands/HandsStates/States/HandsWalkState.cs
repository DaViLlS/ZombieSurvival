using _Project.Development.Core.StateMachine;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Hands.HandsStates.States
{
    public class HandsWalkState : IState
    {
        private HandsStateMachine _stateMachine;
        
        public HandsWalkState(HandsStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OnEnterState()
        {
            _stateMachine.HandsController.Weapon.WalkAnimation(true);
            
            _stateMachine.InputHandler.OnMovementCancelled += OnMovementCancelled;
            _stateMachine.InputHandler.OnAttackPerformed += OnAttackPerformed;
            _stateMachine.InputHandler.OnShiftPerformed += OnShiftPerformed;
        }

        public void OnExitState()
        {
            _stateMachine.InputHandler.OnMovementCancelled -= OnMovementCancelled;
            _stateMachine.InputHandler.OnAttackPerformed -= OnAttackPerformed;
            _stateMachine.InputHandler.OnShiftPerformed -= OnShiftPerformed;
        }
        
        public void Execute() { }

        public void FixedExecute() { }

        private void OnMovementCancelled()
        {
            _stateMachine.HandsController.Weapon.WalkAnimation(false);
            _stateMachine.ChangeStateByType(HandsStateType.Idle);
        }
        
        private void OnAttackPerformed()
        {
            _stateMachine.HandsController.Weapon.WalkAnimation(false);
            _stateMachine.ChangeStateByType(HandsStateType.Attack);
        }
        
        private void OnShiftPerformed()
        {
            _stateMachine.ChangeStateByType(HandsStateType.Run);
        }
    }
}