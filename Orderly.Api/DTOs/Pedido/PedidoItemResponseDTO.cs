using System;

namespace Orderly.Api.DTOs.Pedido;

public class PedidoItemResponseDTO
{
    public Guid ProdutoId { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
    public decimal Subtotal { get; set; }
}
