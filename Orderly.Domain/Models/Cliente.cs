using Orderly.Domain.Common;
using System.Text.RegularExpressions;

namespace Orderly.Domain.Models;

public class Cliente : AuditableEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; } = string.Empty;

    public ICollection<Pedido> Pedidos { get; private set; } = new List<Pedido>();

    protected Cliente() { }

    public Cliente(string nome, string email)
    {
        Nome = nome;
        AtualizarEmail(email);
    }

    public void AtualizarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio");

        Nome = nome;
    }

    public void AtualizarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email não pode ser vazio");

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Email inválido");

        Email = email.ToLower();
    }
}



