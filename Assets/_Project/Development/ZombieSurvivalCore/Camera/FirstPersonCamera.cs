using Assets._Project.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

public class FirstPersonCamera : MonoBehaviour
{
    [Inject] private InputHandler _inputHandler;

    [SerializeField] private float mouseSensitivity = 2f;

    private float _rotationX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _rotationX -= _inputHandler.MouseYAxis;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}
