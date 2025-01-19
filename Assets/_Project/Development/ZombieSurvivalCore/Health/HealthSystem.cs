using System;

namespace _Project.Development.ZombieSurvivalCore.Health
{
    public class HealthSystem
    {
        public event Action OnHealthChanged;
        
        private float _initialHealth;
        private float _currentHealth;
        
        public float InitialHealth => _initialHealth;
        public float CurrentHealth => _currentHealth;
        
        public HealthSystem(float initialHealth)
        {
            _initialHealth = initialHealth;
            _currentHealth = _initialHealth;
        }

        public void ReduceHealth(float health)
        {
            _currentHealth -= health;
            OnHealthChanged?.Invoke();
        }

        public void IncreaseHealth(float health)
        {
            _currentHealth += health;
            OnHealthChanged?.Invoke();
        }

        public void ResetHealth()
        {
            _currentHealth = _initialHealth;
            OnHealthChanged?.Invoke();
        }
    }
}