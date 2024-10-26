using ProductsApi.Models.Product;
using System.Data;

namespace ProductsApi.Mappers.Interfaces
{
    public interface IProductMapper
    {
        public Product? MapProduct(IDataReader reader);

        public List<Product> MapProducts(IDataReader reader);
    }
}
