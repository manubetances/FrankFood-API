using FrankFood.Models;
using FrankFood.ServiceErrors;
using ErrorOr;

namespace FrankFood.Services.Products;

public class ProductService : IProductService
{
    private static readonly Dictionary<Guid, Product> _products = new();

    public ErrorOr<Created> CreateProduct(Product product)
    {
        _products.Add(product.Id, product);

        return Result.Created;
    }

    public ErrorOr<Product> GetProduct(Guid id)
    {
        // Try to get the breakfast with the ID.
        // If the product exists, return it
        if (_products.TryGetValue(id, out var product))
        {
            return product;
        }

        // If it doesnt exist return the error
        return Errors.Product.NotFound;
    }

    public ErrorOr<UpsertedProduct> UpsertProduct(Product product)
    {
        // If the products dictionary does not contain that ID, we create a new one
        var isNewlyCreated = !_products.ContainsKey(product.Id);
        _products[product.Id] = product;

        return new UpsertedProduct(isNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteProduct(Guid id)
    {
        _products.Remove(id);

        return Result.Deleted;
    }
}