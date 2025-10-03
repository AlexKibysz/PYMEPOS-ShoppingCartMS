// <copyright file="ShoppingCartController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

using PYMEPOS_ShoppingCartMS.Models;

using PYMEPOS_ShoppingCartService.Contracts;
using PYMEPOS_ShoppingCartService.Services;

namespace PYMEPOS_ShoppingCartMS.Controllers;

/// <summary>
///     Controller for managing shopping cart operations.
/// </summary>
[ApiController]
[Route("shoppingcart")]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _service;

    public ShoppingCartController(ShoppingCartService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Adds products to the shopping cart.
    /// </summary>
    /// <param name="products">The list of products to add to the cart.</param>
    /// <returns>Nothing is returned as this method has a void return type.</returns>
    [HttpPost("CreateCartWithTestProducts")]
    public async Task<IActionResult> CreateCartWithTestProducts()
    {
        var newShoppingCart = await _service.CreateCartWithTestProducts();

        return Ok(newShoppingCart);
    }

    [HttpGet("{cartId}")]
    public async Task<IActionResult> GetCartbyId(Guid cartId)
    {
        if (cartId == Guid.Empty) return BadRequest("Invalid cart ID.");

        var cart = await _service.GetCartbyId(cartId);

        if (cart.Id != null) return Ok(cart);

        return NotFound();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllCartsAndProducts()
    {
        var cartWithProducts = await _service.GetAllCartsAndProducts();

        if (cartWithProducts != null) return Ok(cartWithProducts);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCart()
    {
        try
        {
            var cartId = await _service.CreateCart();

            return Ok(cartId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("{cartId}")]
    public async Task<IActionResult> DeleteCart(Guid cartId)
    {
        var DeletedCartId = await _service.DeleteCart(cartId);

        return Ok(DeletedCartId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCart(ShoppingCart cart)
    {
        await _service.UpdateCart(cart);

        return NoContent();
    }
}