using System.Collections;
using _Project.Development.Core.PlayerInput;
using _Project.Development.ZombieSurvivalCore.Persons.MainCharacter;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Development.ZombieSurvivalCore.Camera
{
    public class CameraShake : MonoBehaviour
    {
        [Inject] private InputHandler _inputHandler;
        
        [SerializeField] private Character character;
        [SerializeField] private FirstPersonCamera firstPersonCamera;
        
        [SerializeField] private float bobSpeed = 0.2f; // Скорость покачивания камеры
        [SerializeField] private float bobAmount = 0.04f; // Амплитуда покачивания камеры
        [SerializeField] private float midpoint; // Средняя точка покачивания камеры
        [Header("Camera Shoot Shake")]
        [SerializeField] private float shootShakeDuration;
        [SerializeField] private float shootShakeMagnitude;
        [SerializeField] private float shootShakeNoise;
        [Header("Camera Jump Shake")]
        [SerializeField] private float jumpShakeDuration;
        [SerializeField] private float jumpAngleDeg;
        [SerializeField] private Vector2 jumpDirection;
        
        private float timer;

        private void Awake()
        {
            _inputHandler.OnJumpPerformed += OnJumpPerformed;
        }

        private void OnJumpPerformed()
        {
            character.OnCharacterGrounded += OnCharacterGrounded;
        }

        private void OnCharacterGrounded()
        {
            character.OnCharacterGrounded -= OnCharacterGrounded;
            ShakeRotateCamera(0.15f, 2, new Vector2(0.1f, 0f) + Vector2.down);
        }
        
        private void PerformShootShake()
        {
            ShakeCamera(shootShakeDuration, shootShakeMagnitude, shootShakeNoise);
        }
        
        public void ShakeRotateCamera(float duration, float angleDeg, Vector2 direction)
        {
            StartCoroutine(ShakeRotateRoutine(duration, angleDeg, direction));
        }

        public void ShakeCamera(float duration, float magnitude, float noise)
        {
            StartCoroutine(CameraShakeRoutine(duration, magnitude, noise));
        }

        private IEnumerator ShakeRotateRoutine(float duration, float angleDeg, Vector2 direction)
        {
            var elapsed = 0f;
            var startRotation = transform.localRotation;
            var halfDuration = duration / 2f;
            direction = direction.normalized;

            while (elapsed < duration)
            {
                var currentDirection = direction;
                var t = elapsed < halfDuration ? elapsed / halfDuration : (duration - elapsed) / halfDuration;
                var currentAngle = Mathf.Lerp(0f, angleDeg, t);
                currentDirection *= Mathf.Tan(currentAngle * Mathf.Deg2Rad);
                var resDirection = ((Vector3)currentDirection + Vector3.forward).normalized;
                var newRotation = Quaternion.FromToRotation(Vector3.forward, resDirection);
                transform.localRotation = Quaternion.Euler(firstPersonCamera.RotationX, newRotation.y, newRotation.z);
                
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            transform.localRotation = startRotation;
        }

        private IEnumerator CameraShakeRoutine(float duration, float magnitude, float noise)
        {
            var elapsed = 0f;
            var startPosition = transform.localPosition;
            var noiseStartPoint0 = Random.insideUnitCircle * noise;
            var noiseStartPoint1 = Random.insideUnitCircle * noise;

            while (elapsed < duration)
            {
                var currentNoisePoint0 = Vector2.Lerp(noiseStartPoint0, Vector2.zero, elapsed / duration);
                var currentNoisePoint1 = Vector2.Lerp(noiseStartPoint1, Vector2.zero, elapsed / duration);
                var cameraPositionDelta = new Vector2(Mathf.PerlinNoise(currentNoisePoint0.x, currentNoisePoint0.y),
                    Mathf.PerlinNoise(currentNoisePoint1.x, currentNoisePoint1.y));
                cameraPositionDelta *= magnitude;
                
                transform.localPosition = startPosition + (Vector3)cameraPositionDelta;
                
                elapsed += Time.deltaTime;
                yield return null;
            }
            
            transform.localPosition = startPosition;
        }
        
        private void Update()
        {
            var waveSlice = 0.0f;
            var horizontal = _inputHandler.MovementVector.x;
            var vertical = _inputHandler.MovementVector.y;

            if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
            {
                timer = 0.0f;
            }
            else
            {
                waveSlice = Mathf.Sin(timer);
                timer += bobSpeed;
                if (timer > Mathf.PI * 2)
                {
                    timer -= Mathf.PI * 2;
                }
            }

            var cameraPos = transform.localPosition;
            
            if (waveSlice != 0)
            {
                var translateChange = waveSlice * bobAmount;
                var totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                cameraPos.y = midpoint + translateChange;
            }
            else
            {
                cameraPos.y = midpoint;
            }

            transform.localPosition = cameraPos;
        }
    }
}