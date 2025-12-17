using Orderly.Api.Models;

namespace Orderly.Api.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext db)
    {
        if (db.Products.Any()) return;

        db.Products.AddRange(
            new Product { Name = "Camiseta", Description = "Alguma camiseta", Price = 39.90m, Stock = 50 },
            new Product { Name = "Caneca", Description = "Caneca do time", Price = 24.50m, Stock = 100 },
            new Product { Name = "Caderno", Description = "A5", Price = 12.00m, Stock = 200 }
        );

        db.SaveChanges();
    }
}

