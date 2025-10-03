using PYMEPOS_ShoppingCartMS.Models;

namespace PYMEPOS_ShoppingCartService.Contracts;

public interface IProductService
{
    public Task<Product> GetProductById(int productId);

    public Task<List<Product>> GetAllProducts();
}