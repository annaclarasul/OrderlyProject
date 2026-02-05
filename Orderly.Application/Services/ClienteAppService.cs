using AutoMapper;
using Orderly.Application.DTOs.Cliente;
using Orderly.Application.Interfaces.Services;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Domain.ValueObjects;

namespace Orderly.Application.Services;


public class ClienteAppService : IClienteAppService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public ClienteAppService(
        IClienteRepository clienteRepository,
        IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<ClienteResponse> CreateAsync(CreateClienteRequest request)
    {
        var email = new Email(request.Email);
        var cliente = new Cliente(request.Nome, email);

        await _clienteRepository.AddAsync(cliente);

        return _mapper.Map<ClienteResponse>(cliente);
    }

    public async Task<IEnumerable<ClienteResponse>> GetAllAsync()
    {
        var clientes = await _clienteRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClienteResponse>>(clientes);
    }

    public async Task<ClienteResponse?> GetByIdAsync(Guid id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        return cliente == null
            ? null
            : _mapper.Map<ClienteResponse>(cliente);
    }

    public async Task<ClienteResponse> UpdateAsync(Guid id, UpdateClienteRequest request)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Cliente não encontrado");

        cliente.AtualizarNome(request.Nome);
        cliente.AtualizarEmail(new Email(request.Email));

        await _clienteRepository.UpdateAsync(cliente);

        return _mapper.Map<ClienteResponse>(cliente);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _clienteRepository.DeleteAsync(id);
    }
}

