namespace Orderly.Application.DTOs.Pedido;

public class CreatePedidoItemRequest
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
}


