using ErrorOr;
using FrankFood.Contracts.Products;
using FrankFood.ServiceErrors;

namespace FrankFood.Models;

public class Product
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 15;
    public const int MinDescriptionLength = 10;
    public const int MaxDescriptionLength = 100;

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Category { get; }
    public string Vendor { get; }
    public DateTime LastModified { get; }
    public List<string> Tags { get; }

    private Product(
        Guid id, 
        string name, 
        string description, 
        string category, 
        string vendor, 
        DateTime lastModified, 
        List<string> tags)
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        Vendor = vendor;
        LastModified = lastModified;
        Tags = tags;
    }

    // Only the Create method can create a product
    public static ErrorOr<Product> Create(
        string name,
        string description,
        string category,
        string vendor,
        List<string> tags,
        Guid? id = null)
    {
        // Enforce Rules
        // Put errors in a list, so if user has more than 1 error it lets them know
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Product.InvalidName);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Product.InvalidDescription);
        }

        // If there exist at least one error, return the list of errors
        if (errors.Count > 0)
        {
            return errors;
        }

        // Enforce invariants
        return new Product(
            id ?? Guid.NewGuid(),
            name,
            description,
            category,
            vendor,
            DateTime.UtcNow,
            tags);
    }

    public static ErrorOr<Product> From(CreateProductRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.Category,
            request.Vendor,
            request.Tags);
    }

    public static ErrorOr<Product> From(Guid id, UpsertProductRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.Category,
            request.Vendor,
            request.Tags,
            id);
    }
}