using PYMEPOS_ShoppingCartData;

using PYMEPOS_ShoppingCartMS.Models;

using PYMEPOS_ShoppingCartService.Contracts;

namespace PYMEPOS_ShoppingCartService.Services;

public class ProductService : IProductService
{
    private readonly IProductsData _data;

    public ProductService(IProductsData data)
    {
        _data = data;
    }

    public async Task<Product> GetProductById(int productId)
    {
        return await _data.GetProductByIdAsync(productId);
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _data.GetAllProductsAsync();
    }
}