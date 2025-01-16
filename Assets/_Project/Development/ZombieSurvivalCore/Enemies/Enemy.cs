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

        private int _currentPointIndex;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            enemyStateMachine.Initialize();
            
            navMeshAgent.speed = speed;
            
            animator.SetBool("IsWalking", true);
        }

        private void Update()
        {
            Chase();
        }

        private void Chase()
        {
            navMeshAgent.destination = target.position;
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