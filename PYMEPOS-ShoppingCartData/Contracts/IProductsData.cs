using PYMEPOS_ShoppingCartMS.Models;

namespace PYMEPOS_ShoppingCartData;

public interface IProductsData
{
    Task<Product> GetProductByIdAsync(int productId);
    Task<List<Product>> GetAllProductsAsync();
}