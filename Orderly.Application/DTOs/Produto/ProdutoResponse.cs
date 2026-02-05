namespace Orderly.Application.DTOs.Produto;

public class ProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}


