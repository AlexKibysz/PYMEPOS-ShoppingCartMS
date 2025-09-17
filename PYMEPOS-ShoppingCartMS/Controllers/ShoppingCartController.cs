using Microsoft.AspNetCore.Mvc;
using PYMEPOS_ShoppingCartMS.DTO;

namespace PYMEPOS_ShoppingCartMS.Controllers;

[Route("shoppingcart")]
public class ShoppingCartController : Controller
{
    [HttpPost]
    public void addToCart(List<Product> products)
    {
        foreach (var product in products)
        {
            
        }
    }



}