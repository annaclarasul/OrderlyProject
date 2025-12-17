using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orderly.Api.Data;
using Orderly.Api.DTOs;
using Orderly.Api.Models;

namespace Orderly.Api.Controllers;

[ApiController]
[Route("api/Orders")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public OrdersController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> Create(CreateOrderDto dto)
    {
        if (!dto.Items.Any())
            return BadRequest("Order must have at least one item.");

        var productIds = dto.Items.Select(i => i.ProductId).ToList();

        var products = await _db.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();

        if (products.Count != dto.Items.Count)
            return BadRequest("One or more products not found.");

        var order = new Order
        {
            CustomerName = dto.CustomerName
        };

        foreach (var item in dto.Items)
        {
            var product = products.First(p => p.Id == item.ProductId);

            if (product.Stock < item.Quantity)
                return BadRequest($"Insufficient stock for product {product.Name}");

            product.Stock -= item.Quantity;

            order.Items.Add(new OrderItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            });
        }

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        var result = _mapper.Map<OrderDto>(order);
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDto>> GetById(int id)
    {
        var order = await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return NotFound();

        return Ok(_mapper.Map<OrderDto>(order));
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderDto>> GetAll()
    {
        var orders = _db.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .ToList();

        var result = _mapper.Map<List<OrderDto>>(orders);
        return Ok(result);
    }

}

