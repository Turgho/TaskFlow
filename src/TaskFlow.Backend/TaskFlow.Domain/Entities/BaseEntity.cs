namespace TaskFlow.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.CreateVersion7(); // Using UUIDv7 for better sorting in databases
}