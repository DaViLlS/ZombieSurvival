using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMovementSettings", menuName = "CharacterSettings/CharacterMovementSettings", order = 51)]
public class CharacterMovementSettings : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float shiftSpeed;
    [SerializeField] private float jumpForce;

    public float Speed => speed;
    public float ShiftSpeed => shiftSpeed;
    public float JumpForce => jumpForce;
}
