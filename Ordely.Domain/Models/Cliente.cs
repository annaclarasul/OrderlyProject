using Orderly.Main.Models;
using Orderly.Main.Common;
using Orderly.Main.ValueObjects;

namespace Orderly.Main.Models;

public class Cliente : Entity
{
    public string Nome { get; private set; }
    public Email Email { get; private set; }

    private readonly List<Pedido> _pedidos = new();
    public IReadOnlyCollection<Pedido> Pedidos => _pedidos.AsReadOnly();

    protected Cliente() { }

    public Cliente(string nome, Email email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório");

        Nome = nome;
        Email = email;
    }

    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("Nome inválido");

        Nome = novoNome;
    }

    public void AtualizarEmail(Email novoEmail)
    {
        Email = novoEmail;
    }
}
