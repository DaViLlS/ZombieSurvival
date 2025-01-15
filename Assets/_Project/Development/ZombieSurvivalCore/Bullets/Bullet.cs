using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float distance;

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            var ray = new Ray(transform.position, transform.forward);
            
            if (Physics.Raycast(ray, out var hit, distance))
            {
                Transform objectHit = hit.transform;
                Debug.Log("Попал в объект: " + objectHit.name);
                
                Destroy(gameObject);
            }
        }
    }
}