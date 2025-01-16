using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates.States
{
    public class EnemyIdleState : IState
    {
        private EnemyStateMachine _enemyStateMachine;

        public EnemyIdleState(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
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