using System.Collections;
using _Project.Development.Core.StateMachine;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates.States
{
    public class EnemyChaseState : IState
    {
        private EnemyStateMachine _enemyStateMachine;
        private Coroutine _coroutine;
        private bool _isAttacking;

        private Enemy Enemy => _enemyStateMachine.Enemy;

        public EnemyChaseState(EnemyStateMachine enemyStateMachine)
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
            Enemy.NavMeshAgent.destination = Enemy.Target.position;
            
            if (_isAttacking)
                return;
            
            if (Vector3.Distance(Enemy.transform.position, Enemy.Target.position) <= Enemy.DistanceToTarget)
            {
                if (_coroutine != null)
                    _enemyStateMachine.StopCoroutine(_coroutine);
                
                Enemy.Animator.SetBool("IsWalking", false);
                Enemy.NavMeshAgent.isStopped = true;
                _coroutine = _enemyStateMachine.StartCoroutine(Attacking());

                return;
            }
            
            if (_coroutine != null)
                _enemyStateMachine.StopCoroutine(_coroutine);

            _isAttacking = false;
            Enemy.Animator.SetBool("IsAttacking", false);
            Enemy.Animator.SetBool("IsWalking", true);
            Enemy.NavMeshAgent.isStopped = false;
        }
        
        private IEnumerator Attacking()
        {
            while (true)
            {
                _isAttacking = true;
                Enemy.Animator.SetBool("IsAttacking", true);
            
                yield return new WaitForSeconds(0.8965517f);
                
                _isAttacking = false;
                Enemy.Animator.SetBool("IsAttacking", false);
                
                yield return new WaitForSeconds(0.5f);
            }
        }

        public void FixedExecute()
        {
            
        }
    }
}