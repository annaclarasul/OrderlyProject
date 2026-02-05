using Orderly.Main.Common;

namespace Orderly.Main.Models;

public class PedidoItem : Entity
{
    public int ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }

    protected PedidoItem() { }

    public PedidoItem(int produtoId, int quantidade, decimal precoUnitario)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");

        if (precoUnitario <= 0)
            throw new ArgumentException("Preço inválido");

        ProdutoId = produtoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public decimal Subtotal()
    {
        return Quantidade * PrecoUnitario;
    }
}
