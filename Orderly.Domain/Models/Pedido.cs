using Orderly.Domain.Common;
using Orderly.Domain.Enums;

namespace Orderly.Domain.Models;

public class Pedido : Entity
{
    private readonly List<PedidoItem> _itens = new();

    public Guid ClienteId { get; private set; }
    public Cliente Cliente { get; private set; } = null!;
    public StatusPedido Status { get; private set; }
    public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

    protected Pedido() { }

    public Pedido(Cliente cliente)
    {
        Id = Guid.NewGuid();
        Cliente = cliente;
        ClienteId = cliente.Id;
        Status = StatusPedido.Criado;
    }

    // ==========================
    // REGRA DE NEGÓCIO
    // ==========================
    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");

        var itemExistente = _itens
            .FirstOrDefault(i => i.ProdutoId == produto.Id);

        if (itemExistente != null)
        {
            itemExistente.AdicionarQuantidade(quantidade);
            return;
        }

        var item = new PedidoItem(
            produto.Id,
            produto.Preco,
            quantidade
        );

        _itens.Add(item);
    }

    public decimal CalcularTotal()
    {
        return _itens.Sum(i => i.Subtotal);
    }

    public void AtualizarStatus(StatusPedido status)
    {
        Status = status;
    }
}






