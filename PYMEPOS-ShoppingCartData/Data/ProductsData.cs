using Microsoft.EntityFrameworkCore;

using PYMEPOS_ShoppingCartMS;
using PYMEPOS_ShoppingCartMS.Models;

namespace PYMEPOS_ShoppingCartData;

public class ProductsData : IProductsData
{
    private readonly ShoppingCartContext _context;

    public ProductsData(ShoppingCartContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}