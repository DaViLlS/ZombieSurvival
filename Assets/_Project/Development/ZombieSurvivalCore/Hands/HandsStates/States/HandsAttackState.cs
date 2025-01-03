using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Hands.HandsStates.States
{
    public class HandsAttackState : IState
    {
        private HandsStateMachine _stateMachine;
        
        public HandsAttackState(HandsStateMachine stateMachine)
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