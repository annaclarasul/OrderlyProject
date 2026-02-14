using AutoMapper;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Interfaces.Services;
using Orderly.Domain.Models;

namespace Orderly.Domain.Services;

public class ProdutoAppService : IProdutoAppService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoAppService(
        IProdutoRepository produtoRepository,
        IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<Produto> CreateAsync(Produto request)
    {
        var produto = new Produto(
            request.Nome,
            request.Preco,
            request.Estoque
        );

        await _produtoRepository.AddAsync(produto);

        return _mapper.Map<Produto>(produto);
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        var produtos = await _produtoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Produto>>(produtos);
    }

    public async Task<Produto?> GetByIdAsync(Guid id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        return produto == null
            ? null
            : _mapper.Map<Produto>(produto);
    }
}

