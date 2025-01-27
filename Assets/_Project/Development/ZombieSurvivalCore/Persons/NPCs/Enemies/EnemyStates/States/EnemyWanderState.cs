using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Persons.NPCs.Enemies.EnemyStates.States
{
    public class EnemyWanderState : IState
    {
        private EnemyStateMachine _enemyStateMachine;
        
        private Enemy Enemy => _enemyStateMachine.Enemy;

        public EnemyWanderState(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
        }
        
        public void OnEnterState()
        {
            Enemy.Animator.SetBool("IsWalking", true);
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