using Orderly.Application.DTOs.Produto;

namespace Orderly.Application.Interfaces.Services;

public interface IProdutoAppService
{
    Task<ProdutoResponse> CreateAsync(CreateProdutoRequest request);
    Task<IEnumerable<ProdutoResponse>> GetAllAsync();
    Task<ProdutoResponse?> GetByIdAsync(Guid id);
}



