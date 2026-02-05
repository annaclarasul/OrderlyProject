using AutoMapper;
using Orderly.Application.DTOs.Pedido;
using Orderly.Application.Interfaces.Services;
using Orderly.Domain.Enums;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;

namespace Orderly.Application.Services;

public class PedidoAppService : IPedidoAppService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public PedidoAppService(
        IPedidoRepository pedidoRepository,
        IClienteRepository clienteRepository,
        IProdutoRepository produtoRepository,
        IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    // =====================
    // CREATE
    // =====================
    public async Task<PedidoResponse> CreateAsync(CreatePedidoRequest request)
    {
        ValidarPedido(request);

        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId)
            ?? throw new KeyNotFoundException("Cliente não encontrado");

        var pedido = new Pedido(cliente);

        foreach (var item in request.Itens)
        {
            var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId)
                ?? throw new KeyNotFoundException($"Produto {item.ProdutoId} não encontrado");

            produto.DebitarEstoque(item.Quantidade);

            pedido.AdicionarItem(
            produto,
            item.Quantidade
            );

            await _produtoRepository.UpdateAsync(produto);
        }

        await _pedidoRepository.AddAsync(pedido);

        return _mapper.Map<PedidoResponse>(pedido);
    }

    // =====================
    // READ ALL
    // =====================
    public async Task<IEnumerable<PedidoResponse>> GetAllAsync()
    {
        var pedidos = await _pedidoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PedidoResponse>>(pedidos);
    }

    // =====================
    // READ BY ID
    // =====================
    public async Task<PedidoResponse?> GetByIdAsync(Guid id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);

        return pedido == null
            ? null
            : _mapper.Map<PedidoResponse>(pedido);
    }

    // =====================
    // UPDATE STATUS
    // =====================
    public async Task AtualizarStatusAsync(Guid pedidoId, StatusPedido novoStatus)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(pedidoId)
            ?? throw new KeyNotFoundException("Pedido não encontrado");

        pedido.AtualizarStatus(novoStatus);

        await _pedidoRepository.UpdateAsync(pedido);
    }

    // =====================
    // VALIDATION
    // =====================
    private static void ValidarPedido(CreatePedidoRequest request)
    {
        if (request.ClienteId == Guid.Empty)
            throw new ArgumentException("ClienteId inválido");

        if (!request.Itens.Any())
            throw new ArgumentException("Pedido deve conter ao menos um item");

        foreach (var item in request.Itens)
        {
            if (item.ProdutoId == Guid.Empty)
                throw new ArgumentException("ProdutoId inválido");

            if (item.Quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero");
        }
    }


}



