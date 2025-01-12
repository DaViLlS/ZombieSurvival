using System;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Hands;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.MainCharacter
{
    public class Character : MonoBehaviour
    {
        public event Action OnCharacterGrounded;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private CharacterMovementSettings characterMovementSettings;
        [SerializeField] private HandsController handsController;

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
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnCharacterGrounded?.Invoke();
        }
    }
}
