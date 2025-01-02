using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.MainCharacter.CharacterStates;
using UnityEngine;

public class CharacterJumpState : IState
{
    private CharacterStateMachine _stateMachine;
    private float _currentSpeed;

    private Rigidbody Rigidbody => _stateMachine.Character.Rigidbody;
    private Transform Transform => _stateMachine.Character.transform;

    public CharacterJumpState(CharacterStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _currentSpeed = _stateMachine.Character.MovementSettings.Speed;
    }

    public void OnEnterState()
    {
        Rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        _stateMachine.Character.OnCharacterGrounded += OnCharacterGrounded;
    }

    public void OnExitState()
    {
        _stateMachine.Character.OnCharacterGrounded -= OnCharacterGrounded;
    }

    private void OnCharacterGrounded()
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
