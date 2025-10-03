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
}