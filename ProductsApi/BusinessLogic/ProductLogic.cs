using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.Models.Product;
using ProductsApi.Repositories.Interfaces;

namespace ProductsApi.BusinessLogic;

public sealed class ProductLogic : IProductLogic
{
    private readonly IProductRepository _productRepository;
    public ProductLogic(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<Product>> GetAsync(CancellationToken cancellationToken)
    {
        return await _productRepository.GetAsync(cancellationToken); ;
       
    }

    public async Task<Product?> GetAsync(int productId, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAsync(productId, cancellationToken);
    }
}
