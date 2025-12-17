using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Orderly.Api.Data;
using Orderly.Api.Models;
using System;
using Xunit;

public class ProductTests
{
    private AppDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task AddProduct_Should_Save()
    {
        using var db = CreateDb();
        var p = new Product { Name = "Teste", Price = 10m, Stock = 5 };
        db.Products.Add(p);
        await db.SaveChangesAsync();

        var saved = await db.Products.FirstOrDefaultAsync(x => x.Name == "Teste");
        saved.Should().NotBeNull();
        saved!.Price.Should().Be(10m);
    }
}

