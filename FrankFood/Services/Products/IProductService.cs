using FrankFood.Models;
using ErrorOr;

namespace FrankFood.Services.Products;

public interface IProductService
{
    ErrorOr<Created> CreateProduct(Product product);

    ErrorOr<Product> GetProduct(Guid id);

    ErrorOr<UpsertedProduct> UpsertProduct(Product product);

    ErrorOr<Deleted> DeleteProduct(Guid id);
}