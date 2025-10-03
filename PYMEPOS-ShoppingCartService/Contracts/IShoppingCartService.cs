using PYMEPOS_ShoppingCartMS.Models;

namespace PYMEPOS_ShoppingCartService.Contracts;

public interface IShoppingCartService
{
    public Task<ShoppingCart> CreateCartWithTestProducts();
    public Task<ShoppingCart> GetCartbyId(Guid cartId);

    public Task<List<ShoppingCart>> GetAllCartsAndProducts();

    public Task<Guid> CreateCart();
    public Task<Guid?> DeleteCart(Guid cartId);


    public Task<Guid?> UpdateCart(ShoppingCart cart);
}