namespace AnimalManager.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CratedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}