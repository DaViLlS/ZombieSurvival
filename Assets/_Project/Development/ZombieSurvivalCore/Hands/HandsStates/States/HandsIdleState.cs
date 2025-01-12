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
            _stateMachine.InputHandler.OnAttackPerformed += OnAttackPerformed;
        }

        public void OnExitState()
        {
            _stateMachine.InputHandler.OnAttackPerformed -= OnAttackPerformed;
        }
        
        public void Execute() { }

        public void FixedExecute() { }

        private void OnAttackPerformed()
        {
            _stateMachine.ChangeStateByType(HandsStateType.Attack);
        }
    }
}