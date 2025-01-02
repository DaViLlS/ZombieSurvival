using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Weapon.WeaponStates.States
{
    public class WeaponIdleState : IState
    {
        private WeaponStateMachine _stateMachine;
        
        public WeaponIdleState(WeaponStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OnEnterState()
        {
            
        }

        public void OnExitState()
        {
            
        }
        public void Execute()
        {
            
        }

        public void FixedExecute()
        {
            
        }
    }
}