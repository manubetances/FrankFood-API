namespace FrankFood.Models;

public class Product
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Category { get; }
    public string Vendor { get; }
    public DateTime LastModified { get; }
    public List<string> Tags { get; }

    public Product(
        Guid id, 
        string name, 
        string description, 
        string category, 
        string vendor, 
        DateTime lastModified, 
        List<string> tags)
    {
        // Enforce invariants
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        Vendor = vendor;
        LastModified = lastModified;
        Tags = tags;
    }
}