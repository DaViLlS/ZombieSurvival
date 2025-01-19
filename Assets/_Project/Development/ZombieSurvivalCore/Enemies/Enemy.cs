using System.Collections;
using System.Collections.Generic;
using _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Development.ZombieSurvivalCore.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private EnemyStateMachine enemyStateMachine;
        [SerializeField] private float speed;
        
        [SerializeField] private List<Transform> testingWaypoints;
        [SerializeField] private Transform target;
        [SerializeField] private float distanceToTarget;

        private Coroutine _coroutine;
        private int _currentPointIndex;
        private bool _isAttacking;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            enemyStateMachine.Initialize();
            
            navMeshAgent.speed = speed;
            
            //animator.SetBool("IsWalking", true);
        }

        private void FixedUpdate()
        {
            //Chase();
        }

        private void Chase()
        {
            navMeshAgent.destination = target.position;
            
            if (_isAttacking)
                return;
            
            if (Vector3.Distance(transform.position, target.position) <= distanceToTarget)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);
                
                animator.SetBool("IsWalking", false);
                navMeshAgent.isStopped = true;
                _coroutine = StartCoroutine(Attacking());

                return;
            }
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _isAttacking = false;
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsWalking", true);
            navMeshAgent.isStopped = false;
        }

        private IEnumerator Attacking()
        {
            while (true)
            {
                _isAttacking = true;
                animator.SetBool("IsAttacking", true);
            
                yield return new WaitForSeconds(0.8965517f);
                
                _isAttacking = false;
                animator.SetBool("IsAttacking", false);
                
                yield return new WaitForSeconds(0.5f);
            }
        } 

        private void Walk()
        {
            if (_currentPointIndex >= testingWaypoints.Count - 1)
                _currentPointIndex = 0;
            
            navMeshAgent.SetDestination(testingWaypoints[_currentPointIndex].position);
                
            if (Vector2.Distance(transform.position, testingWaypoints[_currentPointIndex].position) < 0.2f)
            {
                _currentPointIndex++;
            }
        }
    }
}