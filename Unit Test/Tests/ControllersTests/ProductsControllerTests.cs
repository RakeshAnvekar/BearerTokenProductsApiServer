using Microsoft.Extensions.Logging;
using Moq;
using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.Controllers;
using Unit_Test.Helpers;


namespace Unit_Test.Tests.ControllersTests;

public class ProductsControllerTests
{
    private readonly Mock<IProductLogic> _productLogic;
    private readonly ProductsController _productsController;
    private readonly Mock<ILogger<ProductsController>> _logger;

    public ProductsControllerTests()
    {
        _productLogic = new Mock<IProductLogic>();
        _logger = new Mock<ILogger<ProductsController>>();
        _productsController = new ProductsController(_logger.Object, _productLogic.Object);
    }

    [Test]
    public async Task GetProductsDetailsSuccessfullyRetrieved()
    {
        // Arrange
        DataHelper dataHelper = new DataHelper();
       _productLogic.Setup(service => service.GetAsync(CancellationToken.None))
                     .ReturnsAsync(dataHelper.products);

        // Act
        var res = await _productsController.Get();

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(res);
     }
    [Test]
    public async Task GetProductsByIdSuccessfullyRetrieved()
    {
        // Arrange
        int id = 1;
        DataHelper dataHelper = new DataHelper();
        _productLogic.Setup(service => service.GetAsync(id, CancellationToken.None))
                      .ReturnsAsync(dataHelper.products[0]);

        // Act
        var res = await _productsController.Get(id);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(res);
    }
}

