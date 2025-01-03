using System;
using InputActions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Development.Core.PlayerInput
{
    public class InputHandler : MonoBehaviour
    {
        public event Action OnJumpPerformed;
        public event Action OnMovementPerformed;
        public event Action OnMovementCancelled;
        public event Action OnShiftPerformed;
        public event Action OnShiftCancelled;
        public event Action OnAttackPerformed;
        public event Action OnAttackCancelled;

        private PlayerInputActions _inputActions;
        private float _mouseXAxis;
        private float _mouseYAxis;
        private bool _isMovementPerformed;

        public float MouseXAxis => _mouseXAxis;
        public float MouseYAxis => _mouseYAxis;
        public Vector2 MovementVector => _inputActions.Player.Movement.ReadValue<Vector2>();
        public bool IsMovementPerformed => _isMovementPerformed;

        private void Start()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Enable();

            _inputActions.Player.Jump.performed += JumpPerformed;
            _inputActions.Player.Movement.performed += MovementPerformed;
            _inputActions.Player.Movement.canceled += MovementCancelled;
            _inputActions.Player.Shift.performed += ShiftPerformed;
            _inputActions.Player.Shift.canceled += ShiftCancelled;
            _inputActions.Player.Attack.performed += AttackPerformed;
            _inputActions.Player.Attack.canceled += AttackCancelled;
        }

        private void Update()
        {
            _mouseXAxis = Input.GetAxis("Mouse X");
            _mouseYAxis = Input.GetAxis("Mouse Y");
        }

        private void MovementPerformed(InputAction.CallbackContext context)
        {
            _isMovementPerformed = true;
            OnMovementPerformed?.Invoke();
            Debug.Log("Movement performed");
        }

        private void MovementCancelled(InputAction.CallbackContext context)
        {
            _isMovementPerformed = false;
            OnMovementCancelled?.Invoke();
            Debug.Log("Movement cancelled");
        }

        private void JumpPerformed(InputAction.CallbackContext context)
        {
            OnJumpPerformed?.Invoke();
            Debug.Log("Jump performed");
        }

        private void ShiftPerformed(InputAction.CallbackContext context)
        {
            OnShiftPerformed?.Invoke();
            Debug.Log("Shift performed");
        }

        private void ShiftCancelled(InputAction.CallbackContext context)
        {
            OnShiftCancelled?.Invoke();
            Debug.Log("Shift cancelled");
        }

        private void AttackPerformed(InputAction.CallbackContext context)
        {
            OnAttackPerformed?.Invoke();
            Debug.Log("Attack performed");
        }
        
        private void AttackCancelled(InputAction.CallbackContext context)
        {
            OnAttackCancelled?.Invoke();
            Debug.Log("Attack cancelled");
        }
    }
}