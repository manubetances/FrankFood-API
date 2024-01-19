using FrankFood.Models;

namespace FrankFood.Services.Products;

public class ProductService : IProductService
{
    private readonly Dictionary<Guid, Product> _products = new();

    public void CreateProduct(Product product)
    {
        _products.Add(product.Id, product);
    }

    public Product GetProduct(Guid id)
    {
        return _products[id];
    }
}