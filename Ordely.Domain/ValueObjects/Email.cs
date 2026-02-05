using System.Text.RegularExpressions;

namespace Orderly.Main.ValueObjects;

public class Email
{
    public string Value { get; }

    protected Email() { }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email não pode ser vazio");

        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Email inválido");

        Value = value.ToLowerInvariant();
    }

    public override string ToString()
    {
        return Value;
    }
}
