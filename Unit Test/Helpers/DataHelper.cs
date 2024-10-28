

using ProductsApi.Models.Product;
using ProductsApi.Models.User;

namespace Unit_Test.Helpers;

internal sealed class DataHelper
{
    public List<Product> products { get; set; } = new()
    {
        new Product{ Id = 1,ProductName="Test Product",Price=10.00m,CategoryType="Eletric"},
        new Product{ Id = 2,ProductName="Test Product 2",Price=10.00m,CategoryType="Eletric"},
    };  
}
