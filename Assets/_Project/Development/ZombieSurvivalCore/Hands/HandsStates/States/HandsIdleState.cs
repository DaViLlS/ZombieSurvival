using _Project.Development.Core.StateMachine;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Hands.HandsStates.States
{
    public class HandsIdleState : IState
    {
        private HandsStateMachine _stateMachine;
        
        public HandsIdleState(HandsStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OnEnterState()
        {
            _stateMachine.InputHandler.OnMovementPerformed += OnMovementPerformed;
            _stateMachine.InputHandler.OnJumpPerformed += OnJumpPerformed;
            _stateMachine.InputHandler.OnAttackPerformed += OnAttackPerformed;
        }

        public void OnExitState()
        {
            _stateMachine.InputHandler.OnMovementPerformed -= OnMovementPerformed;
            _stateMachine.InputHandler.OnJumpPerformed -= OnJumpPerformed;
            _stateMachine.InputHandler.OnAttackPerformed -= OnAttackPerformed;
        }
        
        public void Execute() { }

        public void FixedExecute() { }
        
        private void OnMovementPerformed()
        {
            _stateMachine.ChangeStateByType(HandsStateType.Walk);
        }

        private void OnJumpPerformed()
        {
            
        }

        private void OnAttackPerformed()
        {
            _stateMachine.ChangeStateByType(HandsStateType.Attack);
        }
    }
}