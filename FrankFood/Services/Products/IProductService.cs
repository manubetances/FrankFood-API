using FrankFood.Models;

namespace FrankFood.Services.Products;

public interface IProductService
{
    void CreateProduct(Product product);

    Product GetProduct(Guid id);
}