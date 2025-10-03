using Microsoft.EntityFrameworkCore;

using PYMEPOS_ShoppingCartData;

using PYMEPOS_ShoppingCartService.Contracts;
using PYMEPOS_ShoppingCartService.Services;

namespace PYMEPOS_ShoppingCartMS;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddScoped<IShoppingCartsData, ShoppingCartsData>();


        builder.Services.AddDbContext<ShoppingCartContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) app.MapOpenApi();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}