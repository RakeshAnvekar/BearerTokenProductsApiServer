using Moq;
using ProductsApi.BusinessLogic;
using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.Controllers;
using ProductsApi.Models.Product;
using ProductsApi.Repositories.Interfaces;
using Unit_Test.Helpers;

namespace Unit_Test.Tests.BusinessLogicTests;

public sealed class ProductLogicTests
{
    private readonly Mock<IProductRepository> _productRepositorycMock;
    private readonly IProductLogic _productLogic;

    public ProductLogicTests()
    {
        _productRepositorycMock= new Mock<IProductRepository>();
        _productLogic = new ProductLogic(_productRepositorycMock.Object);

    }
    [Test]
    public async Task GetAsync_SuccessfullyReturnsAllProducts()
    {
        // Arrange
        DataHelper dataHelper = new DataHelper();
       
       _productRepositorycMock.Setup(repo => repo.GetAsync(CancellationToken.None)).ReturnsAsync(dataHelper.products);
        var result = await _productLogic.GetAsync(CancellationToken.None);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, dataHelper.products);
    }
    [Test]
    public async Task GetAsync_SuccessfullyReturnsAllProductsById()
    {
        // Arrange
        DataHelper dataHelper = new DataHelper();

        _productRepositorycMock.Setup(repo => repo.GetAsync(1, CancellationToken.None)).ReturnsAsync(dataHelper.products[1]);
       
        var result = await _productLogic.GetAsync(1,CancellationToken.None);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, dataHelper.products[1]);
    }

}
