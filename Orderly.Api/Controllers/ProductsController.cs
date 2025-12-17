using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orderly.Api.Data;
using Orderly.Api.DTOs;
using Orderly.Api.Models;

namespace Orderly.Api.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public ProductsController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _db.Products.AsNoTracking().ToListAsync();
        return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var p = await _db.Products.FindAsync(id);
        if (p == null) return NotFound();
        return Ok(_mapper.Map<ProductDto>(p));
    }

    // ✅ CREATE CORRETO (UM SÓ)
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        var result = _mapper.Map<ProductDto>(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, result);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateProductDto dto)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return NotFound();

        _mapper.Map(dto, product);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return NotFound();

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}

