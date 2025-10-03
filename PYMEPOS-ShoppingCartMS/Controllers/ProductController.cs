using Microsoft.AspNetCore.Mvc;

using PYMEPOS_ShoppingCartService.Contracts;
using PYMEPOS_ShoppingCartService.Services;

namespace PYMEPOS_ShoppingCartMS.Controllers;

[ApiController]
[Route("product")]
public class ProductController : Controller
{
    private readonly IProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var product = await _service.GetProductById(productId);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.GetAllProducts();

        if (products == null) return NotFound();
        return Ok(products.ToList());
    }
}