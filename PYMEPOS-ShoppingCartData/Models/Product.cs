// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PYMEPOS_ShoppingCartMS.Models;

/// <summary>
/// Represents a product entity with its identifier and quantity.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    public int ProductId
    {
        get; set;
    }

    /// <summary>
    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public int Quantity
    {
        get; set;
    }

    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}