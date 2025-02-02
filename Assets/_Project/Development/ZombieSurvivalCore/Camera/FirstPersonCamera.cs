using _Project.Development.Core.PlayerInput;
using _Project.Development.ZombieSurvivalCore.Persons.MainCharacter;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Camera
{
    public class FirstPersonCamera : MonoBehaviour
    {
        [Inject] private InputHandler _inputHandler;

        [SerializeField] private Character character;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            transform.Rotate(Vector3.left, _inputHandler.MouseYAxis, Space.Self); // Вращение по вертикали
            character.transform.Rotate(Vector3.up, _inputHandler.MouseXAxis, Space.World); // Вращение по горизонтали
        }

        public void Pause()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void Resume()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
