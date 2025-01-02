using System.Collections.Generic;
using _Project.Development.Core.PlayerInput;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Weapon.WeaponStates.States;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Weapon.WeaponStates
{
    public class WeaponStateMachine : StateMachine
    {
        [Inject] private InputHandler inputHandler;
        
        private Dictionary<WeaponStateType, IState> _stateHandlers;
        
        public InputHandler InputHandler => inputHandler;
        
        public override void Initialize()
        {
            _stateHandlers = new Dictionary<WeaponStateType, IState>()
            {
                { WeaponStateType.Idle, new WeaponIdleState(this) }
            };
        }
    }
}