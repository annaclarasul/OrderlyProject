namespace Orderly.Api.Models;

public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);
}
