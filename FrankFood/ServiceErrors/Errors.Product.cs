using ErrorOr;

namespace FrankFood.ServiceErrors;

public static class Errors
{
    public static class Product
    {
        public static Error InvalidName => Error.NotFound(
            code: "Product.InvalidName",
            description: $"Product name must be at least {Models.Product.MinNameLength}" + 
            $" character long and at most {Models.Product.MaxNameLength} characters long");

        public static Error InvalidDescription => Error.NotFound(
            code: "Product.InvalidDescription",
            description: $"Product description must be at least {Models.Product.MinDescriptionLength}" +
            $" character long and at most {Models.Product.MaxDescriptionLength} characters long");

        public static Error NotFound => Error.NotFound(
            code: "Product.NotFound",
            description: "Product not found"
            );
    }
}