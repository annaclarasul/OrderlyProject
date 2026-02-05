using Orderly.Domain.Common;

namespace Orderly.Domain.Models;

public class PedidoItem : Entity
{
    public Guid ProdutoId { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public int Quantidade { get; private set; }
    public Produto Produto { get; private set; }

    protected PedidoItem() { }

    public PedidoItem(Guid produtoId, decimal precoUnitario, int quantidade)
    {
        Id = Guid.NewGuid();
        ProdutoId = produtoId;
        PrecoUnitario = precoUnitario;
        Quantidade = quantidade;
    }

    public decimal Subtotal => PrecoUnitario * Quantidade;

    public void AdicionarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");

        Quantidade += quantidade;
    }
}




