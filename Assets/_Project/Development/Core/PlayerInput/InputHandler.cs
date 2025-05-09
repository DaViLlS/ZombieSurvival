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
        public event Action OnReloadPerformed;

        private PlayerInputActions _inputActions;
        private float _mouseXAxis;
        private float _mouseYAxis;
        private bool _isMovementPerformed;
        private bool _isShiftPerformed;
        private bool _isPaused;

        public float MouseXAxis => _mouseXAxis;
        public float MouseYAxis => _mouseYAxis;
        public Vector2 MovementVector => _inputActions.Player.Movement.ReadValue<Vector2>();
        public bool IsMovementPerformed => _isMovementPerformed;
        public bool IsShiftPerformed => _isShiftPerformed;

        public void Pause()
        {
            _inputActions.Disable();
            _isPaused = true;
        }

        public void Resume()
        {
            _inputActions.Enable();
            _isPaused = false;
        }

        private void Start()
        {
            Cursor.visible = false;
            _inputActions = new PlayerInputActions();
            _inputActions.Enable();

            _inputActions.Player.Jump.performed += JumpPerformed;
            _inputActions.Player.Movement.performed += MovementPerformed;
            _inputActions.Player.Movement.canceled += MovementCancelled;
            _inputActions.Player.Shift.performed += ShiftPerformed;
            _inputActions.Player.Shift.canceled += ShiftCancelled;
            _inputActions.Player.Attack.performed += AttackPerformed;
            _inputActions.Player.Attack.canceled += AttackCancelled;
            _inputActions.Player.Reload.performed += ReloadPerformed;
        }

        private void Update()
        {
            if (_isPaused)
                return;
            
            _mouseXAxis = Input.GetAxis("Mouse X");
            _mouseYAxis = Input.GetAxis("Mouse Y");
        }

        private void MovementPerformed(InputAction.CallbackContext context)
        {
            _isMovementPerformed = true;
            OnMovementPerformed?.Invoke();
        }

        private void MovementCancelled(InputAction.CallbackContext context)
        {
            _isMovementPerformed = false;
            OnMovementCancelled?.Invoke();
        }

        private void JumpPerformed(InputAction.CallbackContext context)
        {
            OnJumpPerformed?.Invoke();
        }

        private void ShiftPerformed(InputAction.CallbackContext context)
        {
            _isShiftPerformed = true;
            OnShiftPerformed?.Invoke();
        }

        private void ShiftCancelled(InputAction.CallbackContext context)
        {
            _isShiftPerformed = false;
            OnShiftCancelled?.Invoke();
        }

        private void AttackPerformed(InputAction.CallbackContext context)
        {
            OnAttackPerformed?.Invoke();
        }
        
        private void AttackCancelled(InputAction.CallbackContext context)
        {
            OnAttackCancelled?.Invoke();
        }

        private void ReloadPerformed(InputAction.CallbackContext context)
        {
            OnReloadPerformed?.Invoke();
        }
    }
}