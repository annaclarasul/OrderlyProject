using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orderly.Application.DTOs.Produto;
using Orderly.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Api.Controllers;

/// <summary>
/// Gerencia o catálogo de produtos do sistema.
/// 
/// Esta API permite:
/// - Cadastrar novos produtos no estoque
/// - Consultar todos os produtos disponíveis
/// - Visualizar detalhes completos de um produto específico
/// 
/// Os produtos representam os itens que podem ser vendidos
/// e vinculados a pedidos no sistema.
/// </summary>
[ApiController]
[Route("api/produtos")]
[Produces("application/json")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoAppService _service;

    public ProdutosController(IProdutoAppService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra um novo produto no sistema.
    /// </summary>
    /// <remarks>
    /// Regras de negócio:
    /// - O nome do produto deve ser único
    /// - O preço deve ser maior que zero
    /// - A quantidade em estoque não pode ser negativa
    /// 
    /// Este endpoint é normalmente utilizado por áreas administrativas
    /// para manter o catálogo de produtos atualizado.
    /// </remarks>
    /// <param name="request">
    /// Dados do produto:
    /// - Nome
    /// - Preço
    /// - Quantidade em estoque
    /// </param>
    /// <returns>
    /// Produto criado com seu identificador único.
    /// </returns>
    /// <response code="201">Produto cadastrado com sucesso.</response>
    /// <response code="400">Dados inválidos ou regras de negócio violadas.</response>
    [HttpPost]
    [ProducesResponseType(typeof(ProdutoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProdutoRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Retorna todos os produtos cadastrados.
    /// </summary>
    /// <remarks>
    /// Ideal para:
    /// - Exibição em catálogos
    /// - Seleção de produtos durante a criação de pedidos
    /// - Auditoria e controle de estoque
    /// </remarks>
    /// <returns>
    /// Lista de produtos com informações de preço e estoque.
    /// </returns>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProdutoResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    /// <summary>
    /// Retorna os detalhes de um produto específico.
    /// </summary>
    /// <param name="id">
    /// Identificador único (Guid) do produto.
    /// </param>
    /// <returns>
    /// Produto com todas as suas informações, incluindo estoque e preço atual.
    /// </returns>
    /// <response code="200">Produto encontrado.</response>
    /// <response code="404">Produto não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ProdutoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }
}


