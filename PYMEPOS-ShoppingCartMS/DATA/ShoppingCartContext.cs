using Microsoft.EntityFrameworkCore;

using PYMEPOS_ShoppingCartMS.Models;


public class ShoppingCartContext : DbContext
{
    public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
        : base(options)
    {
    }

    public DbSet<ShoppingCart> ShoppingCartItems
    {
        get; set;
    }

    public DbSet<Product> Products
    {
        get; set;
    }
}