using Microsoft.EntityFrameworkCore;

using PYMEPOS_ShoppingCartMS.Models;

namespace PYMEPOS_ShoppingCartMS;

public class ShoppingCartContext : DbContext
{
    public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
        : base(options)
    {
    }

    public DbSet<ShoppingCart> ShoppingCarts
    {
        get;
        set;
    }

    public DbSet<Product> Products
    {
        get;
        set;
    }
}