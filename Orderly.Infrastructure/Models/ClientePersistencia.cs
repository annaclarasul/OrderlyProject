using Orderly.Domain.Common;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Models;

public class ClientePersistencia : AuditableEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public ICollection<PedidoPersistencia> Pedidos { get; private set; }

}



