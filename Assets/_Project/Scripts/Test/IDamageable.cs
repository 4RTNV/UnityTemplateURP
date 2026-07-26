namespace _Project.Data
{
    public interface IDamageable
    {
        int Health { get; }

        bool IsAlive { get; }

        void TakeDamage(int damage);
    }
}
