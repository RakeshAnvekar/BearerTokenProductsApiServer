using ProductsApi.DBExecutor.Interfaces;
using ProductsApi.Mappers.Interfaces;
using ProductsApi.Models.Product;
using ProductsApi.Repositories.Interfaces;
using System.Data;

namespace ProductsApi.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly IDbExecutor _dbExecutor;
        private readonly IProductMapper _productMapper;
        public ProductRepository(ILogger<ProductRepository> logger, IDbExecutor dbExecutor, IProductMapper productMapper)
        {
            _logger = logger;
            _dbExecutor = dbExecutor;
            _productMapper = productMapper;
        }
        public Task<List<Product>> GetAsync(CancellationToken cancellationToken)
        {
          var results=  _dbExecutor.ExecuteAsync(DbConstants.Usp_GetProducts, CommandType.StoredProcedure,_productMapper.MapProducts,cancellationToken);
           return results;
        }
    }
}
