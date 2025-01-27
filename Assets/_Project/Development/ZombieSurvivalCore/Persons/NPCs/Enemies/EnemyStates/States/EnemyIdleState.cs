using _Project.Development.Core.StateMachine;

namespace _Project.Development.ZombieSurvivalCore.Persons.NPCs.Enemies.EnemyStates.States
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
            Enemy.EnemyVision.OnCharacterDetected += OnCharacterDetected;
        }

        private void OnCharacterDetected()
        {
            _enemyStateMachine.ChangeStateByType(EnemyStateType.Chase);
        }

        public void OnExitState()
        {
            Enemy.EnemyVision.OnCharacterDetected -= OnCharacterDetected;
        }
        
        public void Execute() { }

        public void FixedExecute() { }
    }
}