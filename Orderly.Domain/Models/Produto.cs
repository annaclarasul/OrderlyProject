using Orderly.Domain.Common;

namespace Orderly.Domain.Models;

public class Produto : AuditableEntity
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    protected Produto() { }

    public Produto(string nome, decimal preco, int estoque)
    {
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void DebitarEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");

        if (quantidade > Estoque)
            throw new InvalidOperationException("Estoque insuficiente");

        Estoque -= quantidade;
    }
}




