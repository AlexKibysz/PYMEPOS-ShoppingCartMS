using System;
using PYMEPOS_ShoppingCartMS.DTO;

namespace PYMEPOS_ShoppingCartMS;

public class shoppingCart
{
   public Guid Id { get; set; }


   public List<Product> Products { get; set; }
}
