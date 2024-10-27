using ProductsApi.Models.User;
using System.Data;

namespace ProductsApi.Mappers.Interfaces;

public interface IUserMapper
{
    public User? MapUser(IDataReader reader);
}
