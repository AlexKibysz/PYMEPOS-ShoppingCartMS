using PYMEPOS_ShoppingCartMS.Models;

namespace PYMEPOS_ShoppingCartData;

public interface IShoppingCartsData
{
    public Task<Guid> AddCartAsync(ShoppingCart cart);
    public Task<ShoppingCart?> GetCartByIdAsync(Guid cartId);
    public Task<List<ShoppingCart>> GetAllCartsAsync();
    public Task<Guid?> DeleteCartAsync(Guid cartId);
    public Task<Guid?> UpdateCartAsync(ShoppingCart cart);
}