// <copyright file="shoppingCart.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace PYMEPOS_ShoppingCartMS.Models;

using System;

/// <summary>
/// Represents a shopping cart containing products.
/// </summary>
public class ProductShoppingCart
{
    public Guid ShoppingCartId
    {
        get; set;
    }
    public ShoppingCart ShoppingCart
    {
        get; set;
    }

    public int ProductId
    {
        get; set;
    }
    public Product Product
    {
        get; set;
    }

    public int Quantity
    {
        get; set;
    }
    public byte Order
    {
        get; set;
    }
}
