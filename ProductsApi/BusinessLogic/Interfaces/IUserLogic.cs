using ProductsApi.Models.User;

namespace ProductsApi.BusinessLogic.Interfaces;

public interface IUserLogic
{
    Task<User?> GetAsync(UserLogin userLogin, CancellationToken cancellationToken);
}
