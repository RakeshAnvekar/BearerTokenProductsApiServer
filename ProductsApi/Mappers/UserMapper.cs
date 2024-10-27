using ProductsApi.Mappers.Interfaces;
using ProductsApi.Models.User;
using System.Data;

namespace ProductsApi.Mappers;

public sealed class UserMapper : IUserMapper
{
    public User? MapUser(IDataReader reader)
    {
        if(!reader.Read()) return null;
        return new User {
            UserId = reader["UserId"]!=null ? Convert.ToInt32(reader["UserId"]):0,
            UserName = reader["UserName"]!=null?(string)(reader["UserName"]):"N/A",
            UserEmail = reader["UserEmail"] != null ? (string)(reader["UserEmail"]) : "N/A",
            UserType = reader["UserType"] != null ? (string)(reader["UserType"]) : "N/A",
            UserPassword ="*******",
        };        
    }
}
