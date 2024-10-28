
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProductsApi.Models.User;
using ProductsApi.Repositories;
using ProductsApi.Repositories.Interfaces;

namespace Unit_Test.Helpers;

internal sealed class InstanceHelper
{
    #region fields
    private readonly DataHelper _dataHelper;
    private readonly ProductRepository? _productRepository;
    private readonly UserRepository? _userRepository;
    #endregion

    #region constructor
    public InstanceHelper(DataHelper dataHelper)
    {
        _dataHelper = dataHelper;
        

    }
    #endregion

    #region methods
    public async Task BuildAsync(CancellationToken cancellationToken)
    {
        var builder = WebApplication.CreateBuilder(Array.Empty<string>());
        builder.Services.AddSingleton(await GetProductRepositoryAsync());
       
    }
    private async Task<IProductRepository> GetProductRepositoryAsync()
    {
        if (_productRepository != null)
        {
            return _productRepository;
        }
        var mock = new Mock<IProductRepository>();
        mock.Setup(static m => m.GetAsync(It.IsAny<CancellationToken>())).ReturnsAsync((CancellationToken _) => _dataHelper.products);
        return await Task.FromResult(mock.Object);

        #endregion
    }

   
    }

