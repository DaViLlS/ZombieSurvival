using _Project.Development.Core.StateMachine;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates.States
{
    public class EnemyChaseState : IState
    {
        private EnemyStateMachine _enemyStateMachine;
        private Coroutine _coroutine;

        private Enemy Enemy => _enemyStateMachine.Enemy;

        public EnemyChaseState(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
        }
        
        public void OnEnterState()
        {
            Enemy.Animator.SetBool("IsWalking", true);
            Enemy.NavMeshAgent.destination = Enemy.Target.transform.position;
            Enemy.NavMeshAgent.isStopped = false;
        }

        public void OnExitState()
        {
            Enemy.Animator.SetBool("IsWalking", false);
            Enemy.NavMeshAgent.isStopped = true;
        }
        
        public void Execute()
        {
            Enemy.NavMeshAgent.destination = Enemy.Target.transform.position;
            
            if (Vector3.Distance(Enemy.transform.position, Enemy.Target.transform.position) <= Enemy.DistanceToTarget)
            {
                _enemyStateMachine.ChangeStateByType(EnemyStateType.Attack);
            }
        }

        public void FixedExecute()
        {
            
        }
    }
}