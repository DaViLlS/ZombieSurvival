using Assets._Project.Scripts.PlayerInput;
using UnityEngine;

public class CharacterMovementState : IState
{
    private CharacterStateMachine _stateMachine;
    private float _currentSpeed;

    private Rigidbody Rigidbody => _stateMachine.Character.Rigidbody;
    private Transform Transform => _stateMachine.Character.transform;

    public CharacterMovementState(CharacterStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _currentSpeed = _stateMachine.Character.MovementSettings.Speed;
    }

    public void Execute()
    {
    }

    public void FixedExecute()
    {
        var moveDirection = Transform.forward * _stateMachine.InputHandler.MovementVector.y + Transform.right * _stateMachine.InputHandler.MovementVector.x;
        Rigidbody.velocity = moveDirection * _currentSpeed + new Vector3(0f, Rigidbody.velocity.y, 0f);
    }

    public void OnEnterState()
    {
        _stateMachine.InputHandler.OnMovementCancelled += OnMovementCancelled;
    }

    private void OnMovementCancelled()
    {
        Rigidbody.velocity = Vector3.zero * _currentSpeed + new Vector3(0f, Rigidbody.velocity.y, 0f);
        _stateMachine.ChangeStateByType(CharacterStateType.Idle);
    }

    public void OnExitState()
    {
        _stateMachine.InputHandler.OnMovementCancelled -= OnMovementCancelled;
    }
}
