using _Project.Development.Core.PlayerInput;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Camera
{
    public class CameraShake : MonoBehaviour
    {
        [Inject] private InputHandler inputHandler;
        
        [SerializeField] private float bobSpeed = 0.2f; // Скорость покачивания камеры
        [SerializeField] private float bobAmount = 0.04f; // Амплитуда покачивания камеры
        [SerializeField] private float midpoint; // Средняя точка покачивания камеры

        private float timer;
        
        private void Update()
        {
            var waveSlice = 0.0f;
            var horizontal = inputHandler.MovementVector.x;
            var vertical = inputHandler.MovementVector.y;

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