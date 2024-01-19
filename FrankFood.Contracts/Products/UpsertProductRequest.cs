namespace FrankFood.Contracts.Products
{
    public record UpsertProductRequest(
        string Name,
        string Description,
        string Category,
        string Vendor,
        List<string> Tags);
}