using AutoMapper;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Interfaces.Services;
using Orderly.Domain.Models;

namespace Orderly.Domain.Services;


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

    public async Task<Cliente> CreateAsync(Cliente request)
    {
        var cliente = new Cliente(request.Nome, request.Email);

        await _clienteRepository.AddAsync(cliente);

        return _mapper.Map<Cliente>(cliente);
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        var clientes = await _clienteRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Cliente>>(clientes);
    }

    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        return cliente == null
            ? null
            : _mapper.Map<Cliente>(cliente);
    }

    public async Task<Cliente> UpdateAsync(Guid id, Cliente request)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Cliente não encontrado");

        cliente.AtualizarNome(request.Nome);
        cliente.AtualizarEmail(request.Email);

        await _clienteRepository.UpdateAsync(cliente);

        return _mapper.Map<Cliente>(cliente);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _clienteRepository.DeleteAsync(id);
    }
}

