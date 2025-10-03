using Moq;

using PYMEPOS_ShoppingCartData;

using PYMEPOS_ShoppingCartMS.Models;

using PYMEPOS_ShoppingCartService.Services;

namespace ShoppingCartMS.Tests;

public class ShoppingCartServiceTests
{
    private readonly Mock<IShoppingCartsData> _mockShoppingCartData = new();

    [Fact]
    public async Task GetCartbyIdIsFound_ReturnCart()
    {
        //Arrange
        var ExistentCartId = Guid.NewGuid();

        var expectedCart = new ShoppingCart
        {
            Id = ExistentCartId
        };
        _mockShoppingCartData.Setup(x => x.GetCartByIdAsync(ExistentCartId)).ReturnsAsync(expectedCart);
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        //Act
        var result = await service.GetCartbyId(ExistentCartId);

        //Assert
        Assert.Equal(expectedCart, result);
    }

    [Fact]
    public async Task GetCartbyIdIsNotFound_ReturnNull()
    {
        //Arrange
        var NonExistingCartId = Guid.NewGuid();

        _mockShoppingCartData.Setup(x => x.GetCartByIdAsync(NonExistingCartId)).ReturnsAsync((ShoppingCart?)null);
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        //Act
        var result = await service.GetCartbyId(NonExistingCartId);

        //Assert
        Assert.Equal(null, result);
    }

    [Fact]
    public async Task GetAllCartsAndProducts_WhenCartsExist_ReturnsNonEmptyList()
    {
        //Arrange

        _mockShoppingCartData.Setup(x => x.GetAllCartsAsync()).ReturnsAsync(new List<ShoppingCart> { new() });
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        //Act
        var Lista = await service.GetAllCartsAndProducts();

        //Assert
        Assert.NotEmpty(Lista);
    }

    [Fact]
    public async Task GetAllCartsAndProducts_WhenCartNotExists_ReturnsEmptyList()
    {
        //Arrange

        _mockShoppingCartData.Setup(x => x.GetAllCartsAsync()).ReturnsAsync(new List<ShoppingCart>());
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        //Act
        var Lista = await service.GetAllCartsAndProducts();

        //Assert
        Assert.Empty(Lista);
    }

    [Fact]
    public async Task CreateCart_shouldReturnGuidOfNewCart()
    {
        //Arrange
        var newShoppingCartId = new ShoppingCart
        {
            Products = new List<Product>(),
            Id = Guid.NewGuid()
        };
        _mockShoppingCartData.Setup(x => x.AddCartAsync(It.IsAny<ShoppingCart>())).ReturnsAsync(newShoppingCartId.Id);
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        //Act
        var IdOfNewCart = await service.CreateCart();


        //Assert
        Assert.Equal(newShoppingCartId.Id, IdOfNewCart);
    }

    [Fact]
    public async Task CreateCart_trowExceptionIfDbFails()
    {
        // Arrange
        _mockShoppingCartData
            .Setup(x => x.AddCartAsync(It.IsAny<ShoppingCart>()))
            .ThrowsAsync(new Exception("DB error"));
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => service.CreateCart());
    }

    [Fact]
    public async Task DeleteCart_IfIdIsValid_shouldReturnGuid()
    {
        //Arrange
        var existentId = Guid.NewGuid();
        _mockShoppingCartData.Setup(x => x.DeleteCartAsync(existentId)).ReturnsAsync(existentId);
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        //Act
        var GuidDevuelto = await service.DeleteCart(existentId);

        //Assert
        Assert.Equal(existentId, GuidDevuelto);
    }

    [Fact]
    public async Task DeleteCart_IfIdIsInvalid_shouldReturnNull()
    {
        //Arrange
        var nonExistentId = Guid.NewGuid();
        _mockShoppingCartData.Setup(x => x.DeleteCartAsync(nonExistentId)).ReturnsAsync((Guid?)null);
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        //Act
        var GuidDevuelto = await service.DeleteCart(nonExistentId);

        //Assert
        Assert.Equal(null, GuidDevuelto);
    }

    [Fact]
    public async Task UpdateCart_WithValidCart_ShouldReturnGuidOfUpdatedCart()
    {
        //Arrange


        var CarritoActualizado = new ShoppingCart
        {
            Products = new List<Product>
            {
                new()
                {
                    ProductId = 1,
                    Quantity = 54
                },
                new()
                {
                    ProductId = 2,
                    Quantity = 2
                }
            },
            Id = Guid.NewGuid()
        };
        _mockShoppingCartData.Setup(x => x.UpdateCartAsync(It.IsAny<ShoppingCart>()))
            .ReturnsAsync(CarritoActualizado.Id);
        var service = new ShoppingCartService(_mockShoppingCartData.Object);


        //Act
        var GuidChangedCart = await service.UpdateCart(CarritoActualizado);

        //Assert
        Assert.Equal(GuidChangedCart, CarritoActualizado.Id);
    }

    [Fact]
    public async Task UpdateCart_WithValidCart_ShouldChangeProductsButNotGUID()
    {
        var originalCart = new ShoppingCart
        {
            Products = new List<Product>
            {
                new() { ProductId = 1, Quantity = 10 },
                new() { ProductId = 2, Quantity = 5 }
            },
            Id = Guid.NewGuid()
        };

        var updatedCart = new ShoppingCart
        {
            Products = new List<Product>
            {
                new() { ProductId = 1, Quantity = 20 },
                new() { ProductId = 3, Quantity = 15 }
            },
            Id = originalCart.Id
        };

        _mockShoppingCartData.Setup(x => x.UpdateCartAsync(It.IsAny<ShoppingCart>())).ReturnsAsync(updatedCart.Id);
        var service = new ShoppingCartService(_mockShoppingCartData.Object);

        var result = await service.UpdateCart(updatedCart);

        Assert.Equal(originalCart.Id, result);
        Assert.NotEqual(originalCart.Products, updatedCart.Products);
    }
}