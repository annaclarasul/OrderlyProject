namespace Orderly.Api.DTOs;

public record ProductDto(int Id, string Name, string? Description, decimal Price, int Stock);
