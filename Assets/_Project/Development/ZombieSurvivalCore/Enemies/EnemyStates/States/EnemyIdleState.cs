using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates.States
{
    public class EnemyIdleState : IState
    {
        private EnemyStateMachine _enemyStateMachine;
        
        private Enemy Enemy => _enemyStateMachine.Enemy;

        public EnemyIdleState(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
        }
        
        public void OnEnterState()
        {
            _enemyStateMachine.Enemy.Animator.SetBool("IsWalking", false);
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