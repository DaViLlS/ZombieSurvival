using System.Collections.Generic;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.MainCharacter.CharacterStates.States;
using Assets._Project.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.MainCharacter.CharacterStates
{
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
                { CharacterStateType.Jump, new CharacterJumpState(this) },
                { CharacterStateType.Shift, new CharacterRunState(this) }
            };

            ChangeStateByType(CharacterStateType.Idle);
        }

        public void ChangeStateByType(CharacterStateType characterStateType)
        {
            ChangeState(_stateHandlers[characterStateType]);
        }
    }
}
