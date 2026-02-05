using Orderly.Application.DTOs.Cliente;

namespace Orderly.Application.Interfaces.Services;

public interface IClienteAppService
{
    Task<ClienteResponse> CreateAsync(CreateClienteRequest request);
    Task<IEnumerable<ClienteResponse>> GetAllAsync();
    Task<ClienteResponse?> GetByIdAsync(Guid id);
    Task<ClienteResponse> UpdateAsync(Guid id, UpdateClienteRequest request);
    Task DeleteAsync(Guid id);
}


