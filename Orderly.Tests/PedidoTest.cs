using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Models;
using Orderly.Domain.ValueObjects;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Repositories;
using System;
using Xunit;

public class PedidoTest
{
    private AppDbContext CriarContexto()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("OrderlyTestDb")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task Deve_Criar_Pedido_Com_Sucesso()
    {
        // Arrange
        var context = CriarContexto();
        var pedidoRepository = new PedidoRepository(context);

        var email = new Email("joao@email.com");

        var cliente = new Cliente("Joao", email);

        context.Clientes.Add(cliente);

        var produto = new Produto("Teclado Gamer com fio", 199m, 10);
        context.Produtos.Add(produto);

        await context.SaveChangesAsync();

        context.Produtos.Add(produto);

        await context.SaveChangesAsync();

        var pedido = new Pedido(cliente);
        pedido.AdicionarItem(produto, 1);

        // Act
        await pedidoRepository.AddAsync(pedido);

        // Assert
        var pedidoSalvo = await pedidoRepository.GetByIdAsync(pedido.Id);
        Assert.NotNull(pedidoSalvo);
        Assert.Equal(199, pedidoSalvo!.CalcularTotal());
    }
}
