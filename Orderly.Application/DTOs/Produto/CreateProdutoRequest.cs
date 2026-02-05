namespace Orderly.Application.DTOs.Produto;

public class CreateProdutoRequest
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}

