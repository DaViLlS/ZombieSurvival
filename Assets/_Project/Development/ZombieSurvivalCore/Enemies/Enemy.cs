using System.Collections;
using System.Collections.Generic;
using _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates;
using _Project.Development.ZombieSurvivalCore.Health;
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
        [SerializeField] private float health;
        [SerializeField] private List<Limb> limbs;

        [SerializeField] private bool chase;
        [SerializeField] private bool walk;
        [SerializeField] private List<Transform> testingWaypoints;
        [SerializeField] private Transform target;
        [SerializeField] private float distanceToTarget;

        private HealthSystem _healthSystem;
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
            _healthSystem = new HealthSystem(health);
            _healthSystem.OnHealthChanged += OnHealthChanged;

            foreach (var limb in limbs)
            {
                limb.OnLimbDamaged += OnLimbDamaged;
            }
        }

        private void OnLimbDamaged(float damage)
        {
            _healthSystem.ReduceHealth(damage);
        }

        private void OnHealthChanged()
        {
            Debug.Log("Current Health: " + _healthSystem.CurrentHealth);

            if (_healthSystem.CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            if (chase)
            {
                animator.SetBool("IsWalking", true);
                Chase();
                return;
            }

            if (walk)
            {
                animator.SetBool("IsWalking", true);
                Walk();
                return;
            }
            
            animator.SetBool("IsWalking", false);
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
    }
}