using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Hands.HandsStates.States
{
    public class HandsRunState : IState
    {
        private HandsStateMachine _stateMachine;
        
        public HandsRunState(HandsStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OnEnterState()
        {
            _stateMachine.HandsController.Weapon.RunAnimation(true);
            
            _stateMachine.InputHandler.OnMovementCancelled += OnMovementCancelled;
            _stateMachine.InputHandler.OnShiftCancelled += OnShiftCancelled;
        }

        public void OnExitState()
        {
            _stateMachine.HandsController.Weapon.RunAnimation(false);
            
            _stateMachine.InputHandler.OnMovementCancelled -= OnMovementCancelled;
            _stateMachine.InputHandler.OnShiftCancelled -= OnShiftCancelled;
        }
        
        public void Execute() { }

        public void FixedExecute() { }

        private void OnMovementCancelled()
        {
            _stateMachine.ChangeStateByType(HandsStateType.Idle);
        }

        private void OnShiftCancelled()
        {
            _stateMachine.ChangeStateByType(HandsStateType.Walk);
        }
    }
}