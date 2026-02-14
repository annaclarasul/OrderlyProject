using System;
using System.Collections.Generic;

namespace Orderly.Api.DTOs.Pedido;

public class CreatePedidoRequestDTO
{
    public Guid ClienteId { get; set; }
    public List<CreatePedidoItemRequestDTO> Itens { get; set; } = new();
}


