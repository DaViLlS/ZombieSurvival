using System;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Health
{
    public class Limb : MonoBehaviour
    {
        public event Action<float> OnLimbDamaged;
        
        [SerializeField] private float damageMultiplier;

        public void Damage(float damage)
        {
            Debug.Log($"Applied damage to {gameObject.name}: {damageMultiplier * damage}");
            OnLimbDamaged?.Invoke(damageMultiplier * damage);
        }
    }
}