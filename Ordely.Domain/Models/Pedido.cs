using Orderly.Main.Models;
using Orderly.Main.Common;
using Orderly.Main.Enums;

namespace Orderly.Main.Models;

public class Pedido : Entity
{
    public int ClienteId { get; private set; }
    public Cliente Cliente { get; private set; }

    public DateTime CriadoEm { get; private set; }
    public StatusPedido Status { get; private set; }

    private readonly List<PedidoItem> _itens = new();
    public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

    protected Pedido() { }

    public Pedido(int clienteId)
    {
        ClienteId = clienteId;
        CriadoEm = DateTime.UtcNow;
        Status = StatusPedido.Criado;
    }

    public void AdicionarItem(int produtoId, int quantidade, decimal precoUnitario)
    {
        if (Status != StatusPedido.Criado)
            throw new InvalidOperationException("Pedido não pode ser alterado");

        _itens.Add(new PedidoItem(produtoId, quantidade, precoUnitario));
    }

    public decimal CalcularTotal()
    {
        return _itens.Sum(i => i.Subtotal());
    }

    public void MarcarComoPago()
    {
        if (Status != StatusPedido.Criado)
            throw new InvalidOperationException("Pedido não pode ser pago");

        Status = StatusPedido.Pago;
    }

    public void Cancelar()
    {
        if (Status == StatusPedido.Enviado)
            throw new InvalidOperationException("Pedido já foi enviado");

        Status = StatusPedido.Cancelado;
    }
}

