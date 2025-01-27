using System;
using _Project.Development.Core.Pause;
using _Project.Development.Core.PersonsCore;
using _Project.Development.Core.PlayerInput;
using _Project.Development.Core.StateMachine;
using _Project.Development.Core.UIBase;
using _Project.Development.ZombieSurvivalCore.Camera;
using _Project.Development.ZombieSurvivalCore.Hands;
using _Project.Development.ZombieSurvivalCore.Health;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Persons.MainCharacter
{
    public class Character : BasePerson, IDamageable, IPauseable
    {
        [Inject] private InputHandler _inputHandler;
        [Inject] private UISystem _uiSystem;
        
        public event Action OnCharacterGrounded;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private CharacterMovementSettings characterMovementSettings;
        [SerializeField] private HandsController handsController;
        [SerializeField] private FirstPersonCamera firstPersonCamera;
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
                GamePause.Instance.PauseGame();
                _uiSystem.ShowWindow("Death");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                OnCharacterGrounded?.Invoke();
        }

        public void Resume()
        {
            firstPersonCamera.Resume();
            _inputHandler.Resume();
            stateMachine.Resume();
        }

        public void Pause()
        {
            firstPersonCamera.Pause();
            _inputHandler.Pause();
            stateMachine.Pause();
        }
    }
}
