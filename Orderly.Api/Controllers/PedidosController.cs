using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orderly.Api.DTOs.Pedido;
using Orderly.Domain.Interfaces.Services;
using Orderly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Api.Controllers;

/// <summary>
/// Gerencia os pedidos do sistema.
/// 
/// Esta API permite:
/// - Criar novos pedidos vinculados a clientes
/// - Consultar todos os pedidos cadastrados
/// - Obter detalhes completos de um pedido específico
/// 
/// Cada pedido é identificado por um <see cref="Guid"/> único,
/// garantindo rastreabilidade e integridade no domínio.
/// </summary>
[ApiController]
[Route("api/pedidos")]
[Produces("application/json")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoAppService _service;
    private readonly IMapper _mapper;

    public PedidosController(IPedidoAppService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }



    /// <summary>
    /// Cria um novo pedido no sistema.
    /// </summary>
    /// <remarks>
    /// O pedido deve:
    /// - Estar vinculado a um cliente existente
    /// - Conter pelo menos um item
    /// - Respeitar a quantidade disponível em estoque para cada produto
    /// 
    /// Caso alguma dessas regras seja violada, a operação será rejeitada.
    /// </remarks>
    /// <param name="request">
    /// Dados necessários para criação do pedido:
    /// - Identificador do cliente
    /// - Lista de itens contendo produto e quantidade
    /// </param>
    /// <returns>
    /// Pedido criado com seu identificador único e valor total calculado.
    /// </returns>
    /// <response code="201">Pedido criado com sucesso.</response>
    /// <response code="400">Dados inválidos ou pedido sem itens.</response>
    /// <response code="404">Cliente ou produto não encontrado.</response>
    [HttpPost]
    [ProducesResponseType(typeof(PedidoResponseDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromBody] CreatePedidoRequestDTO request)
    {
        var mapeado = _mapper.Map<Pedido>(request);
        var result = await _service.CreateAsync(mapeado);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Retorna todos os pedidos cadastrados.
    /// </summary>
    /// <remarks>
    /// Este endpoint é ideal para:
    /// - Painéis administrativos
    /// - Relatórios financeiros
    /// - Acompanhamento de pedidos em tempo real
    /// </remarks>
    /// <returns>
    /// Lista completa de pedidos com informações de cliente, status e total.
    /// </returns>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PedidoResponseDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    /// <summary>
    /// Retorna os detalhes de um pedido específico.
    /// </summary>
    /// <param name="id">
    /// Identificador único (Guid) do pedido.
    /// </param>
    /// <returns>
    /// Pedido completo contendo cliente, itens, status e valor total.
    /// </returns>
    /// <response code="200">Pedido encontrado.</response>
    /// <response code="404">Pedido não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PedidoResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }
}


