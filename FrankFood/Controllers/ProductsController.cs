using Microsoft.AspNetCore.Mvc;
using FrankFood.Contracts.Products;
using FrankFood.Models;
using FrankFood.Services.Products;

namespace FrankFood.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    // POST: Create Product Request
    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest request)
    {
        var product = new Product(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.Category,
            request.Vendor,
            DateTime.UtcNow,
            request.Tags);

        //ToDO: Save to database
        _productService.CreateProduct(product);

        // Take the product created and map it into a response
        var response = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Category,
            product.Vendor,
            product.LastModified,
            product.Tags);

        return CreatedAtAction(
            nameof(CreateProduct),
            new { id = product.Id },
            value: response);
    }

    // GET: Read Product Request
    [HttpGet("{id:guid}")]
    public IActionResult GetProduct(Guid id)
    {
        Product product = _productService.GetProduct(id);

        var response = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Category,
            product.Vendor,
            product.LastModified,
            product.Tags);

        return Ok(response);
    }

    // PUT: Update (Change/Edit) Product Request
    [HttpPut("{id:guid}")]
    public IActionResult UpsertProduct(Guid id, UpsertProductRequest request)
    {
        return Ok(request);
    }

    // DELETE: Delete Products Request
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteProduct(Guid id)
    {
        return Ok(id);
    }
}