using Assets._Project.Scripts.PlayerInput;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterStateMachine : StateMachine
{
    [Inject] private InputHandler inputHandler;

    [SerializeField] private Character character;

    private Dictionary<CharacterStateType, IState> _stateHandlers;

    public InputHandler InputHandler => inputHandler;
    public Character Character => character;

    public override void Initialize()
    {
        gameObject.SetActive(true);

        _stateHandlers = new Dictionary<CharacterStateType, IState>()
        {
            { CharacterStateType.Idle, new CharacterIdleState(this) },
            { CharacterStateType.Move, new CharacterMovementState(this) },
        };

        ChangeStateByType(CharacterStateType.Idle);
    }

    public void ChangeStateByType(CharacterStateType characterStateType)
    {
        ChangeState(_stateHandlers[characterStateType]);
    }
}
