using Orderly.Domain.Common;

namespace Orderly.Infrastructure.Models;

public class ProdutoPersistencia : AuditableEntity
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

}




