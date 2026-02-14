using Orderly.Domain.Common;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Models;

public class PedidoItemPersistencia : Entity
{
    public Guid ProdutoId { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public int Quantidade { get; private set; }
    public ProdutoPersistencia Produto { get; private set; }

}




