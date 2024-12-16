using Assets._Project.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Assets._Project.Scripts.MainCharacter.Test
{
    public class CharacterMovement : MonoBehaviour
    {
        [Inject] private InputHandler _inputHandler;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        [SerializeField] private float shiftSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float rotationSensitivity = 2f;

        private bool _canMove;
        private bool _isGrounded;
        private float _rotationY;
        private float _currentSpeed;


        private void Awake()
        {
            _inputHandler.OnMovementPerformed += OnMovementPerformed;
            _inputHandler.OnMovementCancelled += OnMovementCancelled;
            _inputHandler.OnJumpPerformed += OnJumpPerformed;
            _inputHandler.OnShiftPerformed += OnShiftPerformed;
            _inputHandler.OnShiftCancelled += OnShiftCancelled;

            _currentSpeed = speed;
        }

        private void Update()
        {
            _rotationY += _inputHandler.MouseXAxis;
            transform.localRotation = Quaternion.Euler(0f, _rotationY, 0f);
        }

        private void FixedUpdate()
        {
            if (!_canMove)
                return;

            var moveDirection = transform.forward * _inputHandler.MovementVector.y + transform.right * _inputHandler.MovementVector.x;
            rb.velocity = moveDirection * _currentSpeed + new Vector3(0f, rb.velocity.y, 0f);
        }

        private void OnMovementPerformed()
        {
            _canMove = true;
        }

        private void OnMovementCancelled()
        {
            _canMove = false;
            rb.velocity = Vector3.zero * _currentSpeed + new Vector3(0f, rb.velocity.y, 0f);
        }

        private void OnJumpPerformed()
        {
            if (_isGrounded)
            {
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
                _isGrounded = false;
            }
        }

        private void OnShiftPerformed()
        {
            _currentSpeed = shiftSpeed;
        }

        private void OnShiftCancelled()
        {
            _currentSpeed = speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _isGrounded = true;
        }
    }
}