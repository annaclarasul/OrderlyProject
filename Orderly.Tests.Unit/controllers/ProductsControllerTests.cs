using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orderly.Api.Controllers;
using Orderly.Api.Data;
using Orderly.Api.DTOs;
using Orderly.Api.Models;
using Orderly.Api.Profiles;
using Xunit;

public class ProductsControllerTests
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        // Banco em memória
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _db = new AppDbContext(options);

        // AutoMapper real
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = config.CreateMapper();

        _controller = new ProductsController(_db, _mapper);
    }

    [Fact]
    public async Task Create_ShouldCreateProductSuccessfully()
    {
        // Arrange
        var dto = new CreateProductDto(
      "Produto Teste",
      "Descrição",
      10,
      5
  );


        // Act
        var result = await _controller.Create(dto);

        // Assert
        result.Result.Should().BeOfType<CreatedAtActionResult>();

        var created = (result.Result as CreatedAtActionResult)!.Value as ProductDto;

        created.Should().NotBeNull();
        created!.Name.Should().Be("Produto Teste");
        created.Stock.Should().Be(5);
    }

    [Fact]
    public async Task GetAll_ShouldReturnProducts()
    {
        // Arrange
        _db.Products.Add(new Product
        {
            Name = "Produto 1",
            Description = "Teste",
            Price = 5,
            Stock = 10
        });

        await _db.SaveChangesAsync();

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Result as OkObjectResult;
        okResult.Should().NotBeNull();

        var products = okResult!.Value as IEnumerable<ProductDto>;
        products.Should().HaveCount(1);
    }
}
