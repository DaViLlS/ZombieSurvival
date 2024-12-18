using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event Action OnCharacterGrounded;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private CharacterMovementSettings characterMovementSettings;

    public Rigidbody Rigidbody => rb;
    public CharacterMovementSettings MovementSettings => characterMovementSettings;

    private void Awake()
    {
        stateMachine.Initialize();
    }

    public void Initialize()
    {
        stateMachine.Initialize();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCharacterGrounded?.Invoke();
    }
}
