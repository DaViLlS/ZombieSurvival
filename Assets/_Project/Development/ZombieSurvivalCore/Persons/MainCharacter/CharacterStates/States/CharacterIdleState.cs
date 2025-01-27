using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Persons.MainCharacter.CharacterStates.States
{
    public class CharacterIdleState : IState
    {
        private CharacterStateMachine _stateMachine;

        public CharacterIdleState(CharacterStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnterState()
        {
            _stateMachine.InputHandler.OnMovementPerformed += OnMovementPerformed;
            _stateMachine.InputHandler.OnJumpPerformed += OnJumpPerformed;
        }

        public void OnExitState()
        {
            _stateMachine.InputHandler.OnMovementPerformed -= OnMovementPerformed;
            _stateMachine.InputHandler.OnJumpPerformed -= OnJumpPerformed;
        }

        public void Execute() { }

        public void FixedExecute() { }

        private void OnJumpPerformed()
        {
            _stateMachine.ChangeStateByType(CharacterStateType.Jump);
        }

        private void OnMovementPerformed()
        {
            _stateMachine.ChangeStateByType(CharacterStateType.Move);
        }
    }
}
