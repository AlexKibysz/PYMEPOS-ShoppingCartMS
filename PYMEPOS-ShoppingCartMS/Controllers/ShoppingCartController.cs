// <copyright file="ShoppingCartController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace PYMEPOS_ShoppingCartMS.Controllers;

using Microsoft.AspNetCore.Mvc;

using PYMEPOS_ShoppingCartMS.Models;

/// <summary>
/// Controller for managing shopping cart operations.
/// </summary>
[Route("shoppingcart")]
public class ShoppingCartController : Controller
{
    /// <summary>
    /// Adds products to the shopping cart.
    /// </summary>
    /// <param name="products">The list of products to add to the cart.</param>
    /// <returns>Nothing is returned as this method has a void return type.</returns>

    [HttpPost]
    public void AddToCart(List<Product> products)
    {
        foreach (var product in products)
        {
        }
    }
}