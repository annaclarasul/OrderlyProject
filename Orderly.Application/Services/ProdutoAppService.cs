using AutoMapper;
using Orderly.Application.DTOs.Produto;
using Orderly.Application.Interfaces.Services;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;

namespace Orderly.Application.Services;

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

    public async Task<ProdutoResponse> CreateAsync(CreateProdutoRequest request)
    {
        var produto = new Produto(
            request.Nome,
            request.Preco,
            request.Estoque
        );

        await _produtoRepository.AddAsync(produto);

        return _mapper.Map<ProdutoResponse>(produto);
    }

    public async Task<IEnumerable<ProdutoResponse>> GetAllAsync()
    {
        var produtos = await _produtoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProdutoResponse>>(produtos);
    }

    public async Task<ProdutoResponse?> GetByIdAsync(Guid id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        return produto == null
            ? null
            : _mapper.Map<ProdutoResponse>(produto);
    }
}

