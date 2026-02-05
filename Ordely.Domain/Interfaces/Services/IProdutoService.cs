using Orderly.Main.Models;

public interface IProdutoService
{
    Task AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(int id);
    Task<Produto?> GetByIdAsync(int id);
    Task<IEnumerable<Produto>> GetAllAsync();
}

