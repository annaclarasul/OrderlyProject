namespace Orderly.Application.DTOs.Pedido;

public class CreatePedidoRequest
{
    public Guid ClienteId { get; set; }
    public List<CreatePedidoItemRequest> Itens { get; set; } = new();
}


