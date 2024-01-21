using Microsoft.AspNetCore.Mvc;
using FrankFood.Contracts.Products;
using FrankFood.Models;
using FrankFood.Services.Products;
using ErrorOr;

namespace FrankFood.Controllers;

public class ProductsController : ApiController
{
    private static IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // POST: Create Product Request
    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest request)
    {
        ErrorOr<Product> requestToProductResult = Product.From(request);

        // If its an error, return the error
        if (requestToProductResult.IsError)
        {
            return Problem(requestToProductResult.Errors);
        }

        var product = requestToProductResult.Value;
        ErrorOr<Created> createProductResult = _productService.CreateProduct(product);

        return createProductResult.Match(
            created => CreatedAtGetProduct(product),
            errors => Problem(errors));
    }

    // GET: Read Product Request
    [HttpGet("{id:guid}")]
    public IActionResult GetProduct(Guid id)
    {
        // We receive and error OR a product
        ErrorOr<Product> getproductResult = _productService.GetProduct(id);

        return getproductResult.Match(
            // If we got a product, we map it.
            product => Ok(MapProductResponse(product)),
            // If we got an error, return a problem
            errors => Problem(errors));
    }

    // PUT: Update (Change/Edit) Product Request
    [HttpPut("{id:guid}")]
    public IActionResult UpsertProduct(Guid id, UpsertProductRequest request)
    {
        ErrorOr<Product> requestToProductResult = Product.From(id, request);

        if (requestToProductResult.IsError)
        {
            return Problem(requestToProductResult.Errors);
        }

        var product = requestToProductResult.Value;
        ErrorOr<UpsertedProduct>upsertProductResult = _productService.UpsertProduct(product);

        // Return 201 if a new product is created
        return upsertProductResult.Match(
            // If product is newly created, create a product, if not return No Content
            upserted => upserted.isNewlyCreated ? CreatedAtGetProduct(product) : NoContent(),
            // If we got an error, return a problem
            errors => Problem(errors));
    }

    // DELETE: Delete Products Request
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteProduct(Guid id)
    {
        ErrorOr<Deleted> deleteProductResult = _productService.DeleteProduct(id);

        return deleteProductResult.Match(
            // If it was deleted, it will return no content.
            deleted => NoContent(),
            // If it gives an error, find the appropiate result in "Problems"
            errors => Problem(errors));
    }

    private static ProductResponse MapProductResponse(Product product)
    {
        return new ProductResponse(
                    product.Id,
                    product.Name,
                    product.Description,
                    product.Category,
                    product.Vendor,
                    product.LastModified,
                    product.Tags);
    }

    private IActionResult CreatedAtGetProduct(Product product)
    {
        // Take the product created and map it into a response
        return CreatedAtAction(
            nameof(CreateProduct),
            new { id = product.Id },
            value: MapProductResponse(product));
    }
}