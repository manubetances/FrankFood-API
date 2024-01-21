using FrankFood.Services.Products;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    // Everytime an object request IProductService, create a new ProductServiceObject
    // Use the same service object created.
    builder.Services.AddScoped<IProductService, ProductService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error"); // Middleware to handle errors (similar to try n catch)
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
