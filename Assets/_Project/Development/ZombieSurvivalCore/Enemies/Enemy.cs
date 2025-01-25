using System.Collections.Generic;
using _Project.Development.Core.Pause;
using _Project.Development.ZombieSurvivalCore.Enemies.EnemyStates;
using _Project.Development.ZombieSurvivalCore.Health;
using _Project.Development.ZombieSurvivalCore.MainCharacter;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Enemies
{
    public class Enemy : MonoBehaviour, IPauseable
    {
        [Inject] private Character _character;
        
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private EnemyStateMachine enemyStateMachine;
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float damage;
        [SerializeField] private List<Limb> limbs;
        
        [SerializeField] private List<Transform> testingWaypoints;
        [SerializeField] private float distanceToTarget;

        private HealthSystem _healthSystem;
        private int _currentPointIndex;
        private Transform _target;

        public Transform Target => _target;
        public Animator Animator => animator;
        public NavMeshAgent NavMeshAgent => navMeshAgent;
        public float DistanceToTarget => distanceToTarget;
        public float Damage => damage;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _target = _character.transform;
            
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
        
        public void Resume()
        {
            enemyStateMachine.Resume();
            navMeshAgent.isStopped = false;
        }

        public void Pause()
        {
            enemyStateMachine.Pause();
            navMeshAgent.isStopped = true;
        }

        private void FixedUpdate()
        {
            /*if (walk)
            {
                animator.SetBool("IsWalking", true);
                Walk();
                return;
            }
            
            animator.SetBool("IsWalking", false);*/
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