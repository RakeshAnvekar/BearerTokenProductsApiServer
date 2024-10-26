using ProductsApi.Models.Product;

namespace ProductsApi.BusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        public Task<List<Product>> GetAsync(CancellationToken cancellationToken);
        public Task<Product?> GetAsync(int productId, CancellationToken cancellationToken);
    }
}
