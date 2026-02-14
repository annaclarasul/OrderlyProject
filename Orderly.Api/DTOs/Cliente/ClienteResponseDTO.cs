using System;

namespace Orderly.Api.DTOs.Cliente;

public class ClienteResponseDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
