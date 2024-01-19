namespace FrankFood.Contracts.Products
{
    public record CreateProductRequest(
        string Name,
        string Description,
        string Category,
        string Vendor,
        List<string> Tags);
}
