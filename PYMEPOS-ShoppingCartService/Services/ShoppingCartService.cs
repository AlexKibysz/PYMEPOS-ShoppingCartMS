using PYMEPOS_ShoppingCartData;

using PYMEPOS_ShoppingCartMS.Models;

using PYMEPOS_ShoppingCartService.Contracts;

namespace PYMEPOS_ShoppingCartService.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartsData _data;

    public ShoppingCartService(IShoppingCartsData data)
    {
        _data = data;
    }

    /// <summary>
    ///     Adds products to the shopping cart.
    /// </summary>
    public async Task<ShoppingCart> CreateCartWithTestProducts()
    {
        // Creamos los productos primero
        var product1 = new Product { Quantity = 2 };
        var product2 = new Product { Quantity = 3 };
        var cart = new ShoppingCart
        {
            Id = Guid.NewGuid(),
            Products = new List<Product> { product1, product2 }
        };
        //MANDAR A DATA
        await _data.AddCartAsync(cart);
        //Devolver de Data
        return await _data.GetCartByIdAsync(cart.Id);
    }


    public async Task<ShoppingCart> GetCartbyId(Guid cartId)
    {
        if (cartId == Guid.Empty) return null;


        //mandar  a DATA
        var cart = await _data.GetCartByIdAsync(cartId);


        if (cart == null) return null;

        return cart;
    }


    public async Task<List<ShoppingCart>> GetAllCartsAndProducts()
    {
        var carts = await _data.GetAllCartsAsync();

        if (carts != null) return carts;

        return null;
    }


    public async Task<Guid> CreateCart()
    {
        var cart = new ShoppingCart
        {
            Id = Guid.NewGuid(),
            Products = new List<Product>()
        };
        return await _data.AddCartAsync(cart);
    }


    public async Task<Guid?> DeleteCart(Guid cartId)
    {
        return await _data.DeleteCartAsync(cartId);
    }


    public async Task<Guid?> UpdateCart(ShoppingCart cart)
    {
        return await _data.UpdateCartAsync(cart);
    }
}