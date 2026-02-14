using System;

namespace Orderly.Api.DTOs.Pedido;

public class CreatePedidoItemRequestDTO
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
}


