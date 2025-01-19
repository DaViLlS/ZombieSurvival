using System.Collections;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float distance;
        [SerializeField] private float destroyTime;

        private void Start()
        {
            StartCoroutine(Destroy());
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(destroyTime);
            
            Destroy(gameObject);
        }
    }
}