namespace TaskFlow.Domain.ValueObjects.User;

public class PasswordHash
{
    public string Value { get; }

    private PasswordHash() {}
    
    public PasswordHash(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new ArgumentException("PasswordHash não pode ser vazio.");

        Value = hash;
    }

    // Factory method para criar a partir de senha em texto
    public static PasswordHash FromPlainText(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.");
        
        var hashed = BCrypt.Net.BCrypt.HashPassword(password);
        return new PasswordHash(hashed);
    }

    // Verifica se uma senha bate com o hash
    public bool Verify(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Value);
    }

    public override bool Equals(object? obj)
        => obj is PasswordHash other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}