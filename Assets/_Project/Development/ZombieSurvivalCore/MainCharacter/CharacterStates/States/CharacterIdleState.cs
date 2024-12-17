public class CharacterIdleState : IState
{
    private CharacterStateMachine _stateMachine;

    public CharacterIdleState(CharacterStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Execute()
    {
        
    }

    public void FixedExecute()
    {
        
    }

    public void OnEnterState()
    {
        _stateMachine.InputHandler.OnMovementPerformed += OnMovementPerformed;
    }

    public void OnExitState()
    {
        _stateMachine.InputHandler.OnMovementPerformed -= OnMovementPerformed;
    }

    private void OnMovementPerformed()
    {
        _stateMachine.ChangeStateByType(CharacterStateType.Move);
    }
}
