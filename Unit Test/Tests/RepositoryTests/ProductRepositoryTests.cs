using Microsoft.Extensions.Logging;
using Moq;
using ProductsApi.DBExecutor.Interfaces;
using ProductsApi.Mappers.Interfaces;
using ProductsApi.Models.Product;
using ProductsApi.Repositories;
using ProductsApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Tests.RepositoryTests;

public sealed class ProductRepositoryTests
{
    private  readonly Mock<IDbExecutor> _dbExecutorMock;
    private readonly ProductRepository _repository;
    private readonly Mock<ILogger<ProductRepository>> _logger;
    private readonly Mock<IProductMapper> _productMapperMock;
   
  

    public ProductRepositoryTests()
    {
        _dbExecutorMock = new Mock<IDbExecutor>();
        _logger = new Mock<ILogger<ProductRepository>>();
        _productMapperMock= new Mock<IProductMapper>();
           _repository = new ProductRepository(_logger.Object,_dbExecutorMock.Object, _productMapperMock.Object);
    }

    [Test]
    public async Task GetAsync_Returns_All_ProductsSucessfully()
    {
         _dbExecutorMock.Setup(x => x.ExecuteAsync<Product>(
               It.IsAny<string>(),
               It.IsAny<CommandType>(),
               It.IsAny<Func<IDataReader, Product>>(),
               It.IsAny<CancellationToken>(),
               It.IsAny<Dictionary<string, object?>>()))
           .ReturnsAsync(new Product { Id = 1, ProductName = "Product1" });

        var result = await _repository.GetAsync(CancellationToken.None);
        Assert.IsNotNull(result);
    }
}
