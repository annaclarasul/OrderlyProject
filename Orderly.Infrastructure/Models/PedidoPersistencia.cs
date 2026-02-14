using Orderly.Domain.Common;
using Orderly.Domain.Enums;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Models;

public class PedidoPersistencia : Entity
{
    private readonly List<PedidoItemPersistencia> _itens = new();

    public Guid ClienteId { get; private set; }
    public ClientePersistencia Cliente { get; private set; } = null!;
    public StatusPedido Status { get; private set; }
    public IReadOnlyCollection<PedidoItemPersistencia> Itens => _itens.AsReadOnly();

 
}






