using _Project.Development.Core.PlayerInput;
using _Project.Development.ZombieSurvivalCore.MainCharacter;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Camera
{
    public class FirstPersonCamera : MonoBehaviour
    {
        [Inject] private InputHandler _inputHandler;

        [SerializeField] private Character character;

        private float _rotationX;
        private float _rotationY;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _rotationX -= _inputHandler.MouseYAxis;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);

            _rotationY += _inputHandler.MouseXAxis;
            character.transform.localRotation = Quaternion.Euler(0f, _rotationY, 0f);
        }
    }
}
