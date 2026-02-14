using System;

namespace Orderly.Api.DTOs.Produto;

public class ProdutoResponseDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}


