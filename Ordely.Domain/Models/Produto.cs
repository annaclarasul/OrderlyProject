using Orderly.Main.Common;

namespace Orderly.Main.Models;

public class Produto : Entity
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    protected Produto() { }

    public Produto(string nome, string descricao, decimal preco, int estoque)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome obrigatório");

        if (preco <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        if (estoque < 0)
            throw new ArgumentException("Estoque inválido");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
    }

    public void BaixarEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");

        if (quantidade > Estoque)
            throw new InvalidOperationException("Estoque insuficiente");

        Estoque -= quantidade;
    }

    public void ReporEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");

        Estoque += quantidade;
    }
}
