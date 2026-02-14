using Orderly.Domain.Models;
using Orderly.Domain.Enums;
using Xunit;

namespace Orderly.Tests.Domain;

public class PedidoTest
{
    [Fact]
    public void Deve_Criar_Pedido_Com_Status_Criado()
    {
        var cliente = new Cliente("fulano", "fulano@email.com");

        var pedido = new Pedido(cliente);

        Assert.Equal(StatusPedido.Criado, pedido.Status);
        Assert.Equal(cliente.Id, pedido.ClienteId);
    }

    [Fact]
    public void Deve_Adicionar_Item_Ao_Pedido()
    {
        var cliente = new Cliente("fulano", "fulano@email.com");
        var produto = new Produto("Mouse", 100, 10);

        var pedido = new Pedido(cliente);

        pedido.AdicionarItem(produto, 2);

        Assert.Single(pedido.Itens);
    }

    [Fact]
    public void Deve_Calcular_Total_Corretamente()
    {
        var cliente = new Cliente("fulano", "fulano@email.com");
        var produto = new Produto("Teclado", 200, 10);

        var pedido = new Pedido(cliente);

        pedido.AdicionarItem(produto, 3);

        var total = pedido.CalcularTotal();

        Assert.Equal(600, total);
    }

    [Fact]
    public void Nao_Deve_Permitir_Quantidade_Invalida()
    {
        var cliente = new Cliente("fulano", "fulano@email.com");
        var produto = new Produto("Monitor", 500, 5);

        var pedido = new Pedido(cliente);

        Assert.Throws<ArgumentException>(() =>
            pedido.AdicionarItem(produto, 0)
        );
    }

    [Fact]
    public void Deve_Atualizar_Status_Do_Pedido()
    {
        var cliente = new Cliente("fulano", "fulano@email.com");
        var pedido = new Pedido(cliente);

        pedido.AtualizarStatus(StatusPedido.Pago);

        Assert.Equal(StatusPedido.Pago, pedido.Status);
    }
}
