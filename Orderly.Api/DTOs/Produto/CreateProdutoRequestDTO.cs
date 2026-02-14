namespace Orderly.Api.DTOs.Produto;

public class CreateProdutoRequestDTO
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}

