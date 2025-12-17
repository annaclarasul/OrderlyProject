using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Orderly.Api.DTOs;
using System.Net.Http.Json;
using Xunit;

public class OrdersIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public OrdersIntegrationTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Fact]
    public async Task GetProducts_Should_Return_List()
    {
        var client = _factory.CreateClient();
        var resp = await client.GetAsync("/api/products");
        resp.EnsureSuccessStatusCode();

        var products = await resp.Content.ReadFromJsonAsync<ProductDto[]>();
        products.Should().NotBeNull();
        products!.Length.Should().BeGreaterThanOrEqualTo(1); // seed exists
    }
}

