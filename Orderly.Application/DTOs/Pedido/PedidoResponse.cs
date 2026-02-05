namespace Orderly.Application.DTOs.Pedido;

public class PedidoResponse
{
    public Guid Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public List<PedidoItemResponse> Itens { get; set; } = new();
}
