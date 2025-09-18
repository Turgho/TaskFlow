using System.Text.RegularExpressions;

namespace TaskFlow.Domain.ValueObjects.User;

public class Email
{
    public string Value { get; }

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email não pode ser vazio.");

        // Validação simples de formato
        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!regex.IsMatch(email))
            throw new ArgumentException("Email inválido.");

        Value = email.ToLower(); // normalize
    }

    // Comparação de igualdade
    public override bool Equals(object? obj)
        => obj is Email other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}