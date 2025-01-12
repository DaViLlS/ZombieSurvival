using System.Collections.Generic;
using _Project.Development.Core.PlayerInput;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Hands.HandsStates.States;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Hands.HandsStates
{
    public class HandsStateMachine : StateMachine
    {
        [Inject] private InputHandler inputHandler;
        
        [SerializeField] private HandsController handsController;
        
        private Dictionary<HandsStateType, IState> _stateHandlers;
        
        public InputHandler InputHandler => inputHandler;
        public HandsController HandsController => handsController;
        
        public override void Initialize()
        {
            _stateHandlers = new Dictionary<HandsStateType, IState>()
            {
                { HandsStateType.Idle, new HandsIdleState(this) },
                { HandsStateType.Attack, new HandsAttackState(this) },
                { HandsStateType.Walk, new HandsWalkState(this) },
                { HandsStateType.Run, new HandsRunState(this) }
            };

            ChangeStateByType(HandsStateType.Idle);
        }
        
        public void ChangeStateByType(HandsStateType handsStateType)
        {
            ChangeState(_stateHandlers[handsStateType]);
        }
    }
}