using Orderly.Domain.Common;
using Orderly.Domain.ValueObjects;

namespace Orderly.Domain.Models;

public class Cliente : AuditableEntity
{
    public string Nome { get; private set; }
    public Email Email { get; private set; }

    public ICollection<Pedido> Pedidos { get; private set; }

    protected Cliente() { }

    public Cliente(string nome, Email email)
    {
        Nome = nome;
        Email = email;
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }

    public void AtualizarEmail(Email email)
    {
        Email = email;
    }
}



