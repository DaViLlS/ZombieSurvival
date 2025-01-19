namespace _Project.Development.ZombieSurvivalCore.Health
{
    public interface IDamageable
    {
        public float Health { get; }
        public void ApplyDamage(float damage);
    }
}