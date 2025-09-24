// <copyright file="shoppingCart.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace PYMEPOS_ShoppingCartMS.Models;

using System;

/// <summary>
/// Represents a shopping cart containing products.
/// </summary>
public class ShoppingCart
{
    /// <summary>
    /// Gets or sets the unique identifier for the shopping cart.
    /// </summary>
    public Guid Id
    {
        get; set;
    }

    /// <summary>
    /// Gets or sets the list of products in the shopping cart.
    /// </summary>
    public ICollection<Product> Products
    {
        get; set;
    }

    = new List<Product>();
}
