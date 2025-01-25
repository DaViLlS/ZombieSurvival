using System.Collections;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Health;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates.States
{
    public class EnemyAttackState : IState
    {
        private EnemyStateMachine _enemyStateMachine;
        private Coroutine _coroutine;
        private bool _isAttacking;

        private Enemy Enemy => _enemyStateMachine.Enemy;

        public EnemyAttackState(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
        }
        
        public void OnEnterState()
        {
            Enemy.Animator.SetBool("IsWalking", false);
            Enemy.NavMeshAgent.isStopped = true;
            _coroutine = _enemyStateMachine.StartCoroutine(Attacking());
        }

        public void OnExitState()
        {
            if (_coroutine != null)
                _enemyStateMachine.StopCoroutine(_coroutine);
            
            Enemy.Animator.SetBool("IsAttacking", false);
        }
        
        public void Execute()
        {
            Enemy.NavMeshAgent.destination = Enemy.Target.transform.position;
            
            if (_isAttacking)
                return;
            
            if (Vector3.Distance(Enemy.transform.position, Enemy.Target.transform.position) <= Enemy.DistanceToTarget)
            {
                if (_coroutine != null)
                    _enemyStateMachine.StopCoroutine(_coroutine);
                
                _coroutine = _enemyStateMachine.StartCoroutine(Attacking());

                return;
            }
            
            if (_coroutine != null)
                _enemyStateMachine.StopCoroutine(_coroutine);

            _enemyStateMachine.ChangeStateByType(EnemyStateType.Chase);
        }
        
        private IEnumerator Attacking()
        {
            while (true)
            {
                _isAttacking = true;
                Enemy.Animator.SetBool("IsAttacking", true);
            
                yield return new WaitForSeconds(0.4f);

                if (Vector3.Distance(Enemy.Target.position, Enemy.Target.position) <= Enemy.DistanceToTarget)
                {
                    if (Enemy.Target.TryGetComponent<IDamageable>(out var damageable))
                    {
                        damageable.ApplyDamage(Enemy.Damage);
                    }
                }
                
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