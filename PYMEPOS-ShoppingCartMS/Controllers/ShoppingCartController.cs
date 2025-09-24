// <copyright file="ShoppingCartController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace PYMEPOS_ShoppingCartMS.Controllers;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

using PYMEPOS_ShoppingCartMS.Models;

/// <summary>
/// Controller for managing shopping cart operations.
/// </summary>
[Route("shoppingcart")]
public class ShoppingCartController : Controller
{
    private readonly ShoppingCartContext _context;

    public ShoppingCartController(ShoppingCartContext context)
    {
        _context = context;
    }



    /// <summary>
    /// Adds products to the shopping cart.
    /// </summary>
    /// <param name="products">The list of products to add to the cart.</param>
    /// <returns>Nothing is returned as this method has a void return type.</returns>

    [HttpPost("CreateCartWithTestProducts")]
    public IActionResult CreateCartWithTestProducts()
    {
        // Creamos los productos primero
        var product1 = new Product { Quantity = 2 };
        var product2 = new Product { Quantity = 3 };

        _context.Products.AddRange(product1, product2);

        // Creamos el carrito y asignamos los productos
        var cart = new ShoppingCart
        {
            Id = Guid.NewGuid(),
            Products = new List<Product> { product1, product2 }
        };

        _context.ShoppingCartItems.Add(cart);

        // Guardamos todo en la base de datos
        _context.SaveChanges();

        return Ok(new
        {
            CartId = cart.Id,
            Products = cart.Products.Select(p => new { p.ProductId, p.Quantity })
        });
    }


}