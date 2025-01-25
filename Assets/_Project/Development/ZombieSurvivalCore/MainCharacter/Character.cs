using System;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Hands;
using _Project.Development.ZombieSurvivalCore.Health;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.MainCharacter
{
    public class Character : MonoBehaviour, IDamageable
    {
        public event Action OnCharacterGrounded;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private CharacterMovementSettings characterMovementSettings;
        [SerializeField] private HandsController handsController;
        [SerializeField] private float health;
        
        private HealthSystem _healthSystem;

        public HealthSystem HealthSystem => _healthSystem;
        public Rigidbody Rigidbody => rb;
        public CharacterMovementSettings MovementSettings => characterMovementSettings;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            stateMachine.Initialize();
            handsController.Initialize();
            _healthSystem = new HealthSystem(health);
            _healthSystem.OnHealthChanged += OnHealthChanged;
        }
        
        public float Health => health;
        
        public void ApplyDamage(float damage)
        {
            _healthSystem.ReduceHealth(damage);
        }
        
        private void OnHealthChanged()
        {
            Debug.Log("Current Health: " + _healthSystem.CurrentHealth);

            if (_healthSystem.CurrentHealth <= 0)
            {
                Debug.Log("Ты умер");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                OnCharacterGrounded?.Invoke();
        }
    }
}
