namespace FrankFood.Contracts.Products
{
    public record ProductResponse(
        Guid Id,
        string Name,
        string Description,
        string Category,
        string Vendor,
        DateTime LastModified,
        List<string> Tags);
}