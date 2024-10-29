using ProductsApi.Mappers.Interfaces;
using ProductsApi.Models.Product;
using System.Data;

namespace ProductsApi.Mappers;

public sealed class ProductMapper : IProductMapper
{
    public Product? MapProduct(IDataReader reader)
    {
        if ( reader.Read())
        {
            return new Product
            {
                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                ProductName = reader["ProductName"] != DBNull.Value ? (string)(reader["ProductName"]) : "N/A",
                Price = reader["Price"] != DBNull.Value ? (decimal)(reader["Price"]) : 0.00m,
                CategoryType = reader["CategoryType"] != DBNull.Value ? (string)(reader["CategoryType"]) : "N/A",
            };
        }
        return null;
        
    }

    public List<Product> MapProducts(IDataReader reader)
    {
        var items= new List<Product>();
        while (reader.Read())
        {
            var item = MapProduct(reader);
            if(item != null)
            items.Add(item);
        }
        return items;       
    }
}
