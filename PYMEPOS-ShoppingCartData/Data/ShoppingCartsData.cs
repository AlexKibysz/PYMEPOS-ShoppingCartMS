using Microsoft.EntityFrameworkCore;

using PYMEPOS_ShoppingCartMS;
using PYMEPOS_ShoppingCartMS.Models;

namespace PYMEPOS_ShoppingCartData;

public class ShoppingCartsData : IShoppingCartsData
{
    private readonly ShoppingCartContext _context;

    public ShoppingCartsData(ShoppingCartContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddCartAsync(ShoppingCart cart)
    {
        _context.ShoppingCarts.Add(cart);
        await _context.SaveChangesAsync();
        return cart.Id;
    }

    public async Task<ShoppingCart?> GetCartByIdAsync(Guid cartId)
    {
        return await _context.ShoppingCarts.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == cartId);
    }

    public async Task<List<ShoppingCart>> GetAllCartsAsync()
    {
        return await _context.ShoppingCarts.Include(c => c.Products).ToListAsync();
    }

    public async Task<Guid?> DeleteCartAsync(Guid cartId)
    {
        var cart = await _context.ShoppingCarts.SingleOrDefaultAsync(c => c.Id == cartId);
        if (cart == null) return null;
        _context.ShoppingCarts.Remove(cart);
        await _context.SaveChangesAsync();
        return cart.Id;
    }

    public async Task<Guid?> UpdateCartAsync(ShoppingCart cart)
    {
        var existingCart =
            await _context.ShoppingCarts.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == cart.Id);
        if (existingCart == null) return null;
        existingCart.Products = cart.Products;
        _context.ShoppingCarts.Update(existingCart);
        await _context.SaveChangesAsync();
        return existingCart.Id;
    }
}