using ProductsApi.Models.Product;

namespace ProductsApi.Repositories.Interfaces;

public interface IProductRepository
{
    public Task<List<Product>> GetAsync(CancellationToken cancellationToken);
    public Task<Product?> GetAsync(int id,CancellationToken cancellationToken);
}
