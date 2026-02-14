using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orderly.Api.DTOs.Cliente;
using Orderly.Application.DTOs.Cliente;
using Orderly.Domain.Interfaces.Services;
using Orderly.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orderly.Api.Controllers;

/// <summary>
/// Gerencia todas as operações relacionadas a clientes no sistema.
/// 
/// Esta API permite:
/// - Criar novos clientes
/// - Consultar clientes cadastrados
/// - Atualizar informações de clientes
/// - Remover clientes do sistema
/// 
/// Os clientes são identificados por um <see cref="Guid"/> único,
/// seguindo os princípios de DDD e Clean Architecture.
/// </summary>
[ApiController]
[Route("api/clientes")]
[Produces("application/json")]
public class ClientesController : ControllerBase
{
    private readonly IClienteAppService _service;

    private readonly IMapper _mapper;

    public ClientesController(IMapper mapper, IClienteAppService service)
    {
        _mapper = mapper;
        _service = service;
    }


    /// <summary>
    /// Cria um novo cliente no sistema.
    /// </summary>
    /// <param name="request">
    /// Dados necessários para criar um cliente:
    /// - Nome completo do cliente
    /// - Endereço de e-mail válido
    /// </param>
    /// <returns>
    /// Retorna o cliente recém-criado com seu identificador único (Guid).
    /// </returns>
    /// <response code="201">Cliente criado com sucesso.</response>
    /// <response code="400">Dados inválidos ou e-mail em formato incorreto.</response>
    [HttpPost]
    [ProducesResponseType(typeof(ClienteResponseDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateClienteRequest request)
    {
        var mapeado = _mapper.Map<Cliente>(request);
        var result = await _service.CreateAsync(mapeado);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Retorna a lista de todos os clientes cadastrados.
    /// </summary>
    /// <remarks>
    /// Este endpoint retorna uma coleção completa de clientes.
    /// Ideal para telas administrativas, relatórios e dashboards.
    /// </remarks>
    /// <returns>
    /// Lista de clientes registrados no sistema.
    /// </returns>
    /// <response code="200">Lista retornada com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClienteResponseDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    /// <summary>
    /// Retorna os dados de um cliente específico.
    /// </summary>
    /// <param name="id">
    /// Identificador único (Guid) do cliente.
    /// </param>
    /// <returns>
    /// Dados completos do cliente solicitado.
    /// </returns>
    /// <response code="200">Cliente encontrado.</response>
    /// <response code="404">Cliente não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ClienteResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Atualiza as informações de um cliente existente.
    /// </summary>
    /// <param name="id">
    /// Identificador único (Guid) do cliente que será atualizado.
    /// </param>
    /// <param name="request">
    /// Novos dados do cliente:
    /// - Nome
    /// - E-mail
    /// </param>
    /// <returns>
    /// Cliente atualizado.
    /// </returns>
    /// <response code="200">Cliente atualizado com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>
    /// <response code="400">Dados inválidos.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ClienteResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteRequestDTO request)
    {
        var mapeado = _mapper.Map<Cliente>(request);
        var result = await _service.UpdateAsync(id, mapeado);
        var retotnoMapeado = _mapper.Map<ClienteResponseDTO>(result);
        return Ok(result);
    }

    /// <summary>
    /// Remove um cliente do sistema.
    /// </summary>
    /// <remarks>
    /// Esta operação é irreversível.
    /// Todos os dados relacionados ao cliente poderão ser impactados,
    /// dependendo das regras de negócio aplicadas no domínio.
    /// </remarks>
    /// <param name="id">
    /// Identificador único (Guid) do cliente a ser removido.
    /// </param>
    /// <response code="204">Cliente removido com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}



