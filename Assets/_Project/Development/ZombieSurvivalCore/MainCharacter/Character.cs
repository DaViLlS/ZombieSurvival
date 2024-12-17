using UnityEngine;

public class Character : MonoBehaviour
{
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
}
