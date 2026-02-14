using System;
using System.Collections.Generic;

namespace Orderly.Api.DTOs.Pedido;

public class PedidoResponseDTO
{
    public Guid Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public List<PedidoItemResponseDTO> Itens { get; set; } = new();
}
